using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAddressRepository
    {
        /// <summary>
        /// If you want to fetch address for each employee and the "GetAddressByEmployeeId" method expects EmployeeId. 
        /// That means for each employee, we must call the "GetAddressByEmployeeId" method
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        Task<List<Address>> GetAddressByEmployeeId(int employeeId);


        /// <summary>
        /// Use of this method is good practice, when you want to fetch address for multiple employee 
        /// </summary>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        Task<ILookup<int, Address>> GetAddressesByEmpIds(IEnumerable<int> employeeIds); 
    }
}
