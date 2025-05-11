using System;
using System.Collections.Generic;

namespace EmployeeManagement.DatabaseEntities.Models
{
    public partial class Member
    {
        public Guid MemberId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
    }
}
