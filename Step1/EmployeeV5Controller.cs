using Microsoft.AspNetCore.Mvc;

namespace Step1.DTOsDemo
{

    //DTO Data Transfer object
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV5Controller : ControllerBase
    {
        private static Employee employee = new Employee
        {
            Id = 1,
            UserName = "john123",
            Password = "DemoPassword123",
            Name = "John Doe",
            Age = 28,
            Email = "john@gmail.com",
            PhoneNumber = "9876543210",
            Location = "Bangalore",
            Address = "HSR Layout, Bangalore",
            Department = "IT",
            Designation = "Software Developer",
            Salary = 60000,
            ClientName = "ABC Technologies",
            ClientLocation = "Hyderabad",
            ProjectName = "Banking Application"
        };

        [HttpGet]
        [Route("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            return Ok(employee); // 200 OK
        }

        [HttpGet]
        [Route("GetEmployeeDetailsDTO")]
        public IActionResult GetEmployeeDetailsDTO()
        {

            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                Designation = employee.Designation,
                ProjectName = employee.ProjectName
            };

            return Ok(employeeDTO); // 200 OK
        }

    }

    // ==========================================
    // EMPLOYEE DTO - Selected Information
    // ==========================================

    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string Department { get; set; } = "";

        public string Designation { get; set; } = "";

        public string ProjectName { get; set; } = "";
    }


    // ==========================================
    // EMPLOYEE MODEL - Complete Information
    // ==========================================

    public class Employee
    {
        public int Id { get; set; }

        public string UserName { get; set; } = "";

        public string Password { get; set; } = "";

        public string Name { get; set; } = "";

        public int Age { get; set; }

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string Location { get; set; } = "";

        public string Address { get; set; } = "";

        public string Department { get; set; } = "";

        public string Designation { get; set; } = "";

        public decimal Salary { get; set; }

        public string ClientName { get; set; } = "";

        public string ClientLocation { get; set; } = "";

        public string ProjectName { get; set; } = "";
    }









    //EmployeeWebAPI
    //│
    //├── Controllers
    //│   └── EmployeeController.cs
    //│
    //├── Models
    //│   └── Employee.cs
    //│
    //├── DTOs
    //│   └── EmployeeProfileDto.cs
    //│
    //├── Interfaces
    //│   └── IEmployeeService.cs
    //│
    //├── Services
    //│   └── EmployeeService.cs
    //│
    //└── Program.cs




















}
