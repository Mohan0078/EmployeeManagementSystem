namespace EmployeeManagement.Models.ResponseModel
{
    public class EmployeeResponseModel
    {
        public Guid? EmployeeId { get; set; }
        public Guid? MemberId { get; set; }
        public string Name { get; set; }
        public string? Designation { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public decimal? Salary { get; set; }
        public Guid? StateId { get; set; }
        public string? StateName { get; set; }
    }
}
