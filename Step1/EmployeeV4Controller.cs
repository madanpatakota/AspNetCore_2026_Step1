using Microsoft.AspNetCore.Mvc;

namespace Step1.StatusCodes
{
    //one person why interface uses of that ?

    interface IActionMD
    {
        string OK();
    }

    class myActions : IActionMD
    {
        public string OK()
        {
            return "Success";
        }
    }

    class MyClass
    {
        public IActionMD getResult()
        {
            return new myActions();
        }

        public void Main1()
        {
            var instanceOfMyactions = getResult();
            instanceOfMyactions.OK();
        }

    }


    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV4Controller : ControllerBase
    {

        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new Employee { Id = 2, Name = "Mary", Email = "mary@example.com" },
            new Employee { Id = 3, Name = "Ravi", Email = "ravi@example.com" },
            new Employee { Id = 4, Name = "Ravi Shankar", Email = "ravi.shankar@example.com" }
        };


        public EmployeeV4Controller()
        {

        }


        // GET: api/EmployeeV3/GetAllEmployees
        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }



        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            if (id == 1 || id == 2)
            {
                return Ok("Employee found"); // 200 OK
            }

            return NotFound("Employee not found"); // 404 Not Found
        }


















        //// GET: api/EmployeeV3/GetEmployeeById/2
        //// Diff first and firstordefault
        //// 
        //[HttpGet("GetEmployeeById/{id}")]
        //public Employee? GetEmployeeById([FromRoute] int id)
        //{

        //    //just assume incase of employees data . NO DAta

        //    var x = employees.First(e => e.Id == id);              // Invalid exception
        //    var y = employees.FirstOrDefault(e => e.Id == id);     // null 

        //    return employees.FirstOrDefault(e => e.Id == id);
        //}


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


        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee.Name == "")
            {
                return BadRequest("Name is required");       // 400 Bad Request
            }

            if (employee.Id == 1 || employee.Id == 2)
            {
                return Conflict("Employee already exists");  // 409 Conflict
            }

            employees.Add(employee);

            return Created("", employee);                    // 201 Created
        }




        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(
            int id, [FromBody] Employee employee)
        {
            if (employee.Name == "")
            {
                return BadRequest("Name is required"); // 400 Bad Request
            }

            if (id != 1 && id != 2)
            {
                return NotFound("Employee not found"); // 404 Not Found
            }

            return Ok("Employee updated successfully"); // 200 OK
        }




        [HttpPatch]
        [Route("PatchEmployee/{id}")]
        public IActionResult PatchEmployee(
           int id, [FromBody] Employee employee)
        {
            if (employee.Name == "")
            {
                return BadRequest("Name is required"); // 400 Bad Request
            }

            if (id != 1 && id != 2)
            {
                return NotFound("Employee not found"); // 404 Not Found
            }

            return Ok("Employee partially updated"); // 200 OK
        }







        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id != 1 && id != 2)
            {
                return NotFound("Employee not found"); // 404 Not Found
            }

            //================================

            return NoContent(); // 204 No Content
        }




        [HttpGet]
        [Route("TemporaryEmployeeURL")]
        public IActionResult TemporaryEmployeeURL()
        {
            return Redirect(
                "/api/EmployeeV4/GetAllEmployees"); // 302
        }






        [HttpGet]
        [Route("CheckLogin")]
        public IActionResult CheckLogin(bool isLoggedIn)
        {
            if (isLoggedIn == false)
            {
                return Unauthorized("Please login"); // 401 Unauthorized
            }

            return Ok("Login successful"); // 200 OK
        }















        // redbus     --  Sleeper nonSleeper    -   Driver

        // Sleeper   - creds to get in the bus    -    L1   - seating 

        //                                           -  U1   - sleeping (access denied)
        //                                           



        //creds - cinema hall



        //- cinema   - 150 ruppes


        //   -- 500 rupees 

























        //correct creds - but its 403

        // At which situation i can give deined access ??

        // Give any example real time...



        // Role     -  Admin , Viewer , SuperAdmin , EndUser 

        //   sandipan123
        //   1234567


        // ==========================================
        // 403 Forbidden
        // User does not have permission
        // ==========================================

        [HttpGet]
        [Route("CheckPermission")]
        public IActionResult CheckPermission(bool isAdmin)
        {
            if (isAdmin == false)
            {
                return StatusCode(403, "Access denied"); // 403 Forbidden
            }

            return StatusCode(200, "Access Granted"); // 200 OK
            //return Ok("Access granted"); // 200 OK
        }




        [HttpGet]
        [Route("ServerError")]
        public IActionResult ServerError()
        {
            return StatusCode(500, "Internal Server Error"); // 500
        }



        [HttpGet]
        [Route("ServiceUnavailable")]
        public IActionResult ServiceUnavailable()
        {
            return StatusCode(503, "Service Unavailable"); // 503
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
