using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Step1.ControllerHTTPVerbs
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV3Controller : ControllerBase
    {

        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new Employee { Id = 2, Name = "Mary", Email = "mary@example.com" },
            new Employee { Id = 3, Name = "Ravi", Email = "ravi@example.com" },
            new Employee { Id = 4, Name = "Ravi Shankar", Email = "ravi.shankar@example.com" }
        };


        public EmployeeV3Controller()
        {

        }


        // GET: api/EmployeeV3/GetAllEmployees
        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }



        // GET: api/EmployeeV3/GetEmployeeById/2
        // Diff first and firstordefault
        // 
        [HttpGet("GetEmployeeById/{id}")]
        public Employee? GetEmployeeById([FromRoute] int id)
        {

            //just assume incase of employees data . NO DAta

            var x = employees.First(e => e.Id == id);              // Invalid exception
            var y = employees.FirstOrDefault(e => e.Id == id);     // null 

            return employees.FirstOrDefault(e => e.Id == id);
        }


        // GET: api/Employee/SearchEmployees?name=John
        [HttpGet("SearchEmployees")]
        public List<Employee> SearchEmployees([FromQuery] string name)
        {

            //   JOHN Doe    , JOHN Mary , JOHN abcd  ,  abc JOHN ced  , abc JOHN

            //select * from employees where name  =   'JOHN'

            //select * from employees where name like '%JOHN'

            return employees.Where(e => e.Name.Contains(name)).ToList();
        }




        [HttpGet("GetEmployeeFromHeader")]
        public Employee? GetEmployeeFromHeader([FromHeader(Name = "EmployeeId")] int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }


        // max , min , sum , avg 

        //


        [HttpPost("CreateEmployee")]
        public Employee CreateEmployee([FromBody] Employee employee)
        {
            //employee.Id = employees.Count == 0 ? 1 : employees.Max(e => e.Id) + 1;

            if(employees.Count == 0)
            {
                employee.Id = 1;
            }
            else
            {
                int MaxempID = employees.Max(e => e.Id);
                employee.Id =  MaxempID + 1;
            }


            employees.Add(employee);

            return employee;
        }






        [HttpPut("UpdateEmployee/{id}")]
        public Employee? UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            Employee? existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            return existingEmployee;
        }




        [HttpPatch("PatchEmployee/{id}")]
        public Employee? PatchEmployee([FromRoute] int id, [FromBody] EmployeePatch changes)
        {
            Employee? existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return null;
            }

            if (changes.Name != null)
            {
                existingEmployee.Name = changes.Name;
            }
            if (changes.Email != null)
            {
                existingEmployee.Email = changes.Email;
            }
            return existingEmployee;
        }




        [HttpDelete("DeleteEmployee/{id}")]
        public bool DeleteEmployee([FromRoute] int id)
        {
            Employee? existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return false;
            }

            employees.Remove(existingEmployee);
            return true;
        }












    }


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
    }


    public class EmployeePatch
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }


}
