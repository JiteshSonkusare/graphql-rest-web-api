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
    public class AddressRepository : IAddressRepository
    {
        private readonly EmployeeDBContext _context;

        public AddressRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public Task<List<Address>> GetAddressByEmployeeId(int employeeId)
        {
            return _context.Address.Where(a => a.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<ILookup<int, Address>> GetAddressesByEmpIds(IEnumerable<int> employeeIds)
        {
            var reviews = await _context.Address.Where(a => employeeIds.Contains(a.EmployeeId)).ToListAsync();
            return reviews.ToLookup(r => r.EmployeeId);
        }
    }
}
