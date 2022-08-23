using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.Entities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Department>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllDepartments()
        {
            return StatusCode(StatusCodes.Status200OK, new List<Department>
            {
                new Department
                {
                    DepartmentID = Guid.NewGuid(),
                    DepartmentCode = "D001",
                    DepartmentName = "Phòng hành chính tổng hợp",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Department
                {
                    DepartmentID = Guid.NewGuid(),
                    DepartmentCode = "D002",
                    DepartmentName = "Khối sản xuất",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Department
                {
                    DepartmentID = Guid.NewGuid(),
                    DepartmentCode = "D003",
                    DepartmentName = "Phòng nhân sự",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Department
                {
                    DepartmentID = Guid.NewGuid(),
                    DepartmentCode = "D004",
                    DepartmentName = "Ban giám đốc",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                }
            });
        }
    }
}
