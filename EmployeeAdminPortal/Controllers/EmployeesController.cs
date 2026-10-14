using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Dtos;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController(ApplicationDbContext dbContext) : ControllerBase
{

    // public EmployeesController(ApplicationDbContext dbContext)
    // {
    //     this._dbContext = dbContext;
    // }

    [HttpGet]
    [ProducesResponseType<List<Employee>>(201)]
    public IActionResult GetAllEmployees()
    {
        var allEmployees = dbContext.Employees.ToList();

        return Ok(allEmployees);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Employee), 201)]
    public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
    {
        var employeeEntity = new Employee()
        {
            Name = addEmployeeDto.Name,
            Email = addEmployeeDto.Email,
            Phone = addEmployeeDto.Phone,
            Salary = addEmployeeDto.Salary
        };

        dbContext.Employees.Add(employeeEntity);
        dbContext.SaveChanges(); // EF requires us to confirm our action before committing to the db
        return Ok(employeeEntity);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType<Employee>(200)]
    [ProducesErrorResponseType(typeof(NotFoundResult))]
    public IActionResult GetEmployeeById(Guid id)
    {
        var employee = dbContext.Employees.Find(id);

        if (employee is null)
        {
            return NotFound("Employee not found");
        }

        return Ok(employee);
    }

    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType<Employee>(200)]
    public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updatedEmployeeDto)
    {
        var employee = dbContext.Employees.Find(id);
        if (employee is null)
        {
            return NotFound("Employee not found");
        }

        employee.Name = updatedEmployeeDto.Name;
        employee.Email = updatedEmployeeDto.Email;
        employee.Phone = updatedEmployeeDto.Phone;
        employee.Salary = updatedEmployeeDto.Salary;

        dbContext.SaveChanges();
        return Ok(employee);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType<Employee>(200)]
    public IActionResult DeleteEmployee(Guid id)
    {
        var employee = dbContext.Employees.Find(id);

        if (employee is null)
        {
            return NotFound("Employee not found");
        }
        
        dbContext.Employees.Remove(employee);
        dbContext.SaveChanges();
        return Ok(employee);
    }
}