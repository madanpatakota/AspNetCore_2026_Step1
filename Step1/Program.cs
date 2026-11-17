using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();    // create documetni

builder.Services.AddEndpointsApiExplorer(); // un

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //https://localhost:7273/openapi/v1.json

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });

    app.MapScalarApiReference();


}


//misard.com
//https://localhost:7273

app.MapGet("/", () => "API is running");

//https://localhost:7273/FirstRecord
app.MapGet("/FirstRecord", () => "API First REcord is - JOHN");


//https://localhost:7273/FirstRecord/Peter
app.MapGet("FirstRecord/{customername}", (string customername) =>
    $"API First REcord is - {customername}"
);


app.MapGet("/add/{ a }/{ b}" , (int a , int b)=>  a+b);


app.MapGet("/multiply/{a}/{b}", (int a, int b) =>
{
    int result = a * b;
    return $"The product of {a} and {b} is {result}.";
});



//app.MapGet("FirstRecord/{customername}", (string customername) =>
//{
//    return $"API First REcord is - {customername}";
//}
//);





//https://localhost:7273/html
app.MapGet("/html", () =>
{
    var htmlContent = "<html><body><h1>Hello, World!</h1> </body></html>";
    return Results.Content(htmlContent, "text/html");
});


//REturn html content


//https://www.apsrtconline.in/eticket/oprs-api/rest/booking/customer/getAvailableServiceList


//https://localhost:7273/htmlWithCSS
app.MapGet("/htmlWithCSS", () =>
{
    var htmlContent = "<html><head><style>h1 { color: blue; }</style></head><body><h1>Hello, World!</h1></body></html>";
    return Results.Content(htmlContent, "text/html");
});


//https://localhost:7273/htmlWithJS
app.MapGet("/htmlWithJS", () =>
{
    var htmlContent = "<html><body><h1>Hello, World!</h1><script>alert('Hello from JavaScript!');</script></body></html>";
    return Results.Content(htmlContent, "text/html");
});


//return sql
app.MapGet("/sql", () =>
{
    var sqlContent = "SELECT * FROM Users WHERE IsActive = 1;";
    return Results.Content(sqlContent, "text/plain");
});


//return XML Content
app.MapGet("/xml", () =>
{
    var xmlContent = "<note><to>User</to><from>Server</from><message>Hello, World!</message></note>";
    return Results.Content(xmlContent, "application/xml");
});


app.MapGet("/image", () =>
{
    var imagepath = "wwwroot/images/image.png"; // Ensure this path is correct and the image exists"

    //bytes
    var imageBytes = File.ReadAllBytes(imagepath);
    return Results.File(imageBytes, "image/png");

});


app.MapPost("/CreateRecord", () =>
{
      return "Record Created Successfully";
});


app.MapPost("/CreateEmployee", (Employee employee) =>
{
    return $"YOu have created Employee Successfully . So employee name {employee.Name} and Employee ID is {employee.Id}";
});


// assuming i am updating the meployee id whose is 1
app.MapPut("UpdateEmployee/{id}", (Employee employee) =>
{
    return $"YOu have updated Employee Successfully . so employee detaisl are now {employee.Name} , {employee.Mail} , {employee.Salary} , {employee.Location}";
});


// assuming i am updating the meployee id whose is 1
//Patching work - partial work

//i will update the first record only. any way i wil pass as 1 

//https://localhost:7273/PatchEmployee/1

//Madan , madan@gmail.com
app.MapPatch("PatchEmployee/{id}/{name}/{mail}", (int id , string name , string mail) =>
{
    //my original data
    List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John", Mail = "John@gmail.com" , Location = "Baoglore" , Salary = "2000" },
        new Employee { Id = 2, Name = "Peter", Mail = "peter@gamil.com" , Location = "Hyderabad" , Salary = "3000"}
    };

    Employee firstEmpoyee =  employees.First(x => x.Id == id);  //"JOHN"
    firstEmpoyee.Name = name;
    firstEmpoyee.Mail = mail;


    return $"YOu have updated Employee Successfully . so employee detaisl are now {firstEmpoyee.Name} , {firstEmpoyee.Mail}";
});


//Madan , madan@gmail.com
app.MapDelete("DeleteEmployee/{location}", (string location) =>
{
    //my original data
    List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John", Mail = "John@gmail.com" , Location = "Baoglore" , Salary = "2000" },
        new Employee { Id = 2, Name = "Peter", Mail = "peter@gamil.com" , Location = "Hyderabad" , Salary = "3000"}
    };


    // bangoore --- sql command   where    - List
    // Madn
    // John
    // peter
    // Mark
    // Robert
    // sql -- 

    //Ienumrable - iq
     List<Employee> employeeDatas = employees.Where(x => x.Location == location).ToList();  //"JOHN"

    // here DB operations will be here.

    return employeeDatas;   // Json data
});




app.Run();


class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Mail { get; set; }

    public string Salary { get; set; }

    public string Location { get; set; }



}
