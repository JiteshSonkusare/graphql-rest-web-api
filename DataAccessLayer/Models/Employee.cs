using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AddressNavigation = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Address> AddressNavigation { get; set; }
    }
}
