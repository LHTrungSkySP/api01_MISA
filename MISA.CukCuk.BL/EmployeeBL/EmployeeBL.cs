using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.DL.EmployeeDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.EmployeeBL
{
    public class EmployeeBL : IEmployeeBL
    {
        #region Field
        
        private IEmployeeDL _employeeDL;

        #endregion

        #region Constructor

        public EmployeeBL(IEmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public int DeleteEmployeeByID(Guid employeeID)
        {
            return _employeeDL.DeleteEmployeeByID(employeeID);
        }

        /// <summary>
        /// Sửa 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn sửa</param>
        /// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public PagingData<Employee> FilterEmployees(string? keyword, Guid? positionID, Guid? departmentID, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByID(Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public string GetNewEmployeeCode()
        {
            throw new NotImplementedException();
        }

        public int InsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Guid employeeID, Employee employee)
        {
            throw new NotImplementedException();
        } 

        #endregion
    }
}
