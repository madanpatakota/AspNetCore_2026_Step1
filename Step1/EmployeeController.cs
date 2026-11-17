using Microsoft.AspNetCore.Mvc;

namespace Step1
{

    //localhost:3456/api/[controllername]/________________________

    //localhost:3456/api/Employee/_________________________________
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {

        public EmployeeController()
        {

        }

        //app.MapGet("/FirstRecord", () => "API First REcord is - JOHN");
        //https:localhost:3456/api/Employee/FirstRecord
        [HttpGet]
        [Route("EmployeeTestData")]
        public string GetEmployeeName()
        {
            return "Test Data - JOHN";
        }


        [HttpGet]
        [Route("EmployeeFirstRecord/{customername}")]
        public string GetEmployeeFirstName(string customername)
        {
            return $"API First REcord is - {customername}";
        }


        [HttpGet]
        [Route("GetEmployeesList")]
        public List<Employee> GetEmployeesList()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", 
                    Mail = "john.doe@example.com", Location = "New York" },
                new Employee { Id = 2, Name = "Jane Smith",
                    Mail = "jane.smith@example.com", Location = "Los Angeles" }
            };
        }



        //route - parameter - name - John

        [HttpGet]
        [Route("GetEmployeeByName/{name}")]
        public List<Employee> GetEmployeeByName(string name)
        {
            var employees = EmployeeData();
            return employees.Where(x => x.Name == name).ToList();  // 2 records
        }



        public List<Employee> EmployeeData()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe",
                    Mail = "john.doe@example.com", Location = "New York" },
                new Employee { Id = 3, Name = "John Doe",
                    Mail = "john.doe123@example.com", Location = "India" },
                new Employee { Id = 2, Name = "Jane Smith",
                    Mail = "jane.smith@example.com", Location = "Los Angeles" }
            };
        }


    }
}
