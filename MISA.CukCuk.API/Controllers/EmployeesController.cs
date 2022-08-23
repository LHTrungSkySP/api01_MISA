using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.Entities;
using MISA.CukCuk.API.Enums;
using MySqlConnector;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Method

        /// <summary>
        /// API Thêm mới 1 nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên muốn thêm mới</param>
        /// <returns>ID của nhân viên vừa thêm mới</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult InsertEmployee([FromBody] Employee employee)
        {
            return StatusCode(StatusCodes.Status201Created, Guid.NewGuid());
        }

        /// <summary>
        /// API Sửa 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn sửa</param>
        /// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpPut("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {
            return StatusCode(StatusCodes.Status200OK, employeeID);
        }

        /// <summary>
        /// API Xóa 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>ID của nhân viên vừa xóa</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpDelete("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmployeeByID([FromRoute] Guid employeeID)
        {
            return StatusCode(StatusCodes.Status200OK, employeeID);
        }

        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="positionID">ID vị trí</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Employee>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterEmployees(
            [FromQuery] string? keyword,
            [FromQuery] Guid? positionID, 
            [FromQuery] Guid? departmentID, 
            [FromQuery] int pageSize = 10, 
            [FromQuery] int pageNumber = 1)
        {
            // Object Initialize
            return StatusCode(StatusCodes.Status200OK, new PagingData<Employee>()
            {
                Data = new List<Employee>
                {
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        EmployeeCode = "NV00001",
                        EmployeeName = "Trần Minh Sáng",
                        DateOfBirth = DateTime.UtcNow,
                        Gender = Gender.Male,
                        IdentityNumber = "0231654321",
                        IdentityIssuedPlace = "CA Hà Nội",
                        IdentityIssuedDate = DateTime.UtcNow,
                        Email = "sangtran.d14ptit@gmail.com",
                        PhoneNumber = "0355557796",
                        PositionID = Guid.NewGuid(),
                        PositionName = "Lập trình viên",
                        DepartmentID = Guid.NewGuid(),
                        DepartmentName = "Khối sản xuất",
                        TaxCode = "132165131",
                        Salary = 30000000,
                        JoiningDate = DateTime.UtcNow.AddYears(-3),
                        WorkStatus = WorkStatus.CurrentlyWorking,
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "admin",
                        ModifiedDate = DateTime.UtcNow,
                        ModifiedBy = "admin"
                    },
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        EmployeeCode = "NV00002",
                        EmployeeName = "Nguyễn Văn Mạnh",
                        DateOfBirth = DateTime.UtcNow,
                        Gender = Gender.Male,
                        IdentityNumber = "135456321",
                        IdentityIssuedPlace = "CA Bắc Giang",
                        IdentityIssuedDate = DateTime.UtcNow,
                        Email = "sangtran.d14ptit@gmail.com",
                        PhoneNumber = "0986542512",
                        PositionID = Guid.NewGuid(),
                        PositionName = "HR",
                        DepartmentID = Guid.NewGuid(),
                        DepartmentName = "Phòng nhân sự",
                        TaxCode = "153465132",
                        Salary = 30000000,
                        JoiningDate = DateTime.UtcNow.AddYears(-6),
                        WorkStatus = WorkStatus.Retired,
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "admin",
                        ModifiedDate = DateTime.UtcNow,
                        ModifiedBy = "admin"
                    }
                },
                TotalCount = 2
            });
        }

        /// <summary>
        /// API Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employee))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new Employee
            {
                EmployeeID = Guid.NewGuid(),
                EmployeeCode = "NV00001",
                EmployeeName = "Trần Minh Sáng",
                DateOfBirth = DateTime.UtcNow,
                Gender = Gender.Male,
                IdentityNumber = "0231654321",
                IdentityIssuedPlace = "CA Hà Nội",
                IdentityIssuedDate = DateTime.UtcNow,
                Email = "sangtran.d14ptit@gmail.com",
                PhoneNumber = "0355557796",
                PositionID = Guid.NewGuid(),
                PositionName = "Lập trình viên",
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Khối sản xuất",
                TaxCode = "132165131",
                Salary = 30000000,
                JoiningDate = DateTime.UtcNow.AddYears(-3),
                WorkStatus = WorkStatus.CurrentlyWorking,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "admin",
                ModifiedDate = DateTime.UtcNow,
                ModifiedBy = "admin"
            });
        }

        /// <summary>
        /// Lấy mã nhân viên tự động tăng
        /// </summary>
        /// <returns>
        /// Mã nhân viên tự động tăng
        /// </returns>
        /// Created by: TMSANG (16/08/2022)
        [HttpGet("new-code")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNewEmployeeCode()
        {
            return StatusCode(StatusCodes.Status200OK, "NV00003");
        } 

        #endregion
    }
}
