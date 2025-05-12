using System;
using System.Collections.Generic;

namespace EmployeeManagement.DatabaseEntities.Models
{
    public partial class State
    {
        public State()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid StateId { get; set; }
        public string? StateName { get; set; }
        public string? StateCode { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
