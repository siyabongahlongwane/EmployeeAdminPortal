using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    // base means "Pass these options to the constructor of my parent, DbContext."
    {
    }

    public DbSet<Employee> Employees { get; set; } // Creates essentially the table name
}