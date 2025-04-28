namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
       required 
        public string Name { get; set; }
        public required  string Email { get; set; }

        public string? Phone { get; set; }
        public decimal Salary { get; set; }

    }
}
