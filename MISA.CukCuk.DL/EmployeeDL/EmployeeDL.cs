using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.EmployeeDL
{
    public class EmployeeDL : IEmployeeDL
    {
        public int DeleteEmployeeByID(Guid employeeID)
        {
            // Khởi tạo kết nối tới DB MySQL
            string connectionString = "Server=localhost;Port=3306;Database=misa.web07.qtkd.sang;Uid=root;Pwd=12345678;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Chuẩn bị câu lệnh DELETE
            string deleteEmployeeCommand = "DELETE FROM employee WHERE EmployeeID = @EmployeeID";

            // Chuẩn bị tham số đầu vào cho câu lệnh DELETE
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", employeeID);

            // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
            int numberOfAffectedRows = mySqlConnection.Execute(deleteEmployeeCommand, parameters);

            return numberOfAffectedRows;
        }
    }
}
