using System;
using System.Collections.Generic;

namespace EmployeeManagement.DatabaseEntities.Models
{
    public partial class Member
    {
        public Member()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid MemberId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
