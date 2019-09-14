using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDBContext _context;

        public DepartmentRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        
        public async Task<ILookup<int, Department>> GetDepartmentByEmpIds(IEnumerable<int> departmentIds)
        {
            var reviews = await _context.Department.Where(a => departmentIds.Contains(a.Id)).ToListAsync();
            return reviews.ToLookup(r => r.Id);
        }
    }
}
