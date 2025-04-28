namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeesDto
    {
        required
    public string Name { get; set; }
        public required string Email { get; set; }

        public string? Phone { get; set; }
        public decimal Salary { get; set; }


    }
}
