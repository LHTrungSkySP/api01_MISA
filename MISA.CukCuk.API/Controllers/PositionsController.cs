using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.Entities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Position>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPositions()
        {
            return StatusCode(StatusCodes.Status200OK, new List<Position>
            {
                new Position
                {
                    PositionID = Guid.NewGuid(),
                    PositionCode = "P001",
                    PositionName = "Chủ tịch",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Position
                {
                    PositionID = Guid.NewGuid(),
                    PositionCode = "P002",
                    PositionName = "Tổng giám đốc",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Position
                {
                    PositionID = Guid.NewGuid(),
                    PositionCode = "P003",
                    PositionName = "Trưởng phòng",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Position
                {
                    PositionID = Guid.NewGuid(),
                    PositionCode = "P004",
                    PositionName = "Lập trình viên",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                }
            });
        }
    }
}
