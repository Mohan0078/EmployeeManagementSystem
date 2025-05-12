using System;
using System.Collections.Generic;

namespace EmployeeManagement.DatabaseEntities.Models
{
    public partial class Employee
    {
        public Guid EmployeeId { get; set; }
        public Guid? MemberId { get; set; }
        public string? Designation { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public decimal? Salary { get; set; }
        public Guid? StateId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Member? Member { get; set; }
        public virtual State? State { get; set; }
    }
}
