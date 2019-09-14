using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
