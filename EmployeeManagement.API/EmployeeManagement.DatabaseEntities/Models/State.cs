using System;
using System.Collections.Generic;

namespace EmployeeManagement.DatabaseEntities.Models
{
    public partial class State
    {
        public Guid StateId { get; set; }
        public string? StateName { get; set; }
        public string? StateCode { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
