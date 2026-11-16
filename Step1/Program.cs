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


app.MapGet("/add/{ a:int }/{ b: int}" , (int a , int b)=>  a+b);


app.MapGet("/multiply/{a:int}/{b:int}", (int a, int b) =>
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


app.Run();
