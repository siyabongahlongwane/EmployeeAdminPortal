namespace EmployeeAdminPortal.Models.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; } // ? used to set value as nullable
    public decimal Salary { get; set; }
}