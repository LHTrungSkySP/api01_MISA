using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.WithDapper.Entities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace MISA.CukCuk.API.WithDapper.Controllers
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
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = "Server=localhost;Port=3306;Database=misa.web07.qtkd.sang;Uid=root;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị câu lệnh truy vấn
                string getAllPositionsCommand = "SELECT * FROM positions;";

                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var positions = mySqlConnection.Query<Position>(getAllPositionsCommand);

                // Xử lý dữ liệu trả về
                if (positions != null)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, positions);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
