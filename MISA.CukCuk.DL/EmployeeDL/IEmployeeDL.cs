using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.EmployeeDL
{
    public interface IEmployeeDL
    {
        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public int DeleteEmployeeByID(Guid employeeID);
    }
}
