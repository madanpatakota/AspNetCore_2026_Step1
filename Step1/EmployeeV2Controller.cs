using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Step1
{

    //localhost:3456/api/[controllername]/________________________

    //localhost:3456/api/Employee/_________________________________
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV2Controller : ControllerBase
    {

        public EmployeeV2Controller()
        {

        }





        //  Get with http param single value
        [HttpGet]
        [Route("GetEmployeeById")]
        //complete path is api/Employee/GetEmployeeById?id=1
        public Employee GetEmployeeById(int id)
        {
            // Here, you can implement logic to retrieve a specific employee by ID, such as fetching it from a database.
            // For demonstration purposes, we'll return a sample employee.
            var employee = new Employee
            {
                Id = id,
                Name = $"Employee {id}",
                Mail = $"employee{id}@example.com"
            };

            return employee;
        }




        [HttpGet]
        [Route("GetEmployeeByIdQuery")]
        //complete path is api/Employee/GetEmployeeByIdQuery?id=1
        public Employee GetEmployeeByIdQuery([FromQuery] int id)
        {
            // Here, you can implement logic to retrieve a specific employee by ID, such as fetching it from a database.
            // For demonstration purposes, we'll return a sample employee.
            var employee = new Employee
            {
                Id = id,
                Name = $"Employee {id}",
                Mail = $"employee{id}@example.com",
                Salary = "10000"
            };

            return employee;
        }

        //get



        //Csahrp first step

        [HttpGet]
        [Route("GetEmployeeByIdHeader")]
        //complete path is api/Employee/GetEmployeeByIdQuery?id=1


        //Ny.com


        //https://Ny.com/api/EmployeeV2/GetEmployeeByIdHeader
        public dynamic GetEmployeeByIdHeader([FromHeader] string auth)
        {
            // Here, you can implement logic to retrieve a specific employee by ID, such as fetching it from a database.
            // For demonstration purposes, we'll return a sample employee.
            var anonomousUser = new
            {
                Id = 1,
                Name = "Anonmous",
                token = auth
            };

            return anonomousUser;
        }




        //https://Ny.com/api/EmployeeV2/GetEmployeeByIdBody
        [HttpGet]
        [Route("GetEmployeeByIdBody")]
        public dynamic GetEmployeeByIdBody([FromBody] string auth)
        {
            // Here, you can implement logic to retrieve a specific employee by ID, such as fetching it from a database.
            // For demonstration purposes, we'll return a sample employee.
            var anonomousUser = new
            {
                Id = 1,
                Name = "Anonmous",
                token = auth
            };

            return anonomousUser;
        }


        [HttpGet]
        [Route("GetEmployeeBody")]
        public dynamic GetEmployeeBody([FromBody] Employee auth)
        {
            // Here, you can implement logic to retrieve a specific employee by ID, such as fetching it from a database.
            // For demonstration purposes, we'll return a sample employee.
            var anonomousUser = new
            {
                Id = 1,
                Name = "Anonmous",
                token = auth
            };

            return anonomousUser;
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
