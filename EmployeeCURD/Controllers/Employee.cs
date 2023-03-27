using EmployeeCURD.Data;
using EmployeeCURD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCURD.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController:Controller
    {
        private readonly EmployeeDbContext employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public  IActionResult GetAllEmployees()
        {
            var employees =  employeeDbContext.Employees.ToList();
            return Ok(employees);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetById")]
        public  IActionResult GetById(int id)
        {
            var employee = employeeDbContext.Employees.FirstOrDefault(x=>x.Id==id);
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employee.Id = 0;
            employeeDbContext.Add(employee);
            employeeDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }
        [HttpPut]
        public  IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var dbEmployee =  employeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (dbEmployee == null)
                return BadRequest();

            dbEmployee.Name = employee.Name;
            dbEmployee.Destignation = employee.Destignation;
            dbEmployee.MobileNumber = employee.MobileNumber;
            employeeDbContext.SaveChanges();
           
            return Ok(dbEmployee);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var dbEmployee = employeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (dbEmployee == null)
                return NotFound();

            employeeDbContext.Employees.Remove(dbEmployee);
            employeeDbContext.SaveChanges();
            return Ok(dbEmployee);
        }


    }
}
