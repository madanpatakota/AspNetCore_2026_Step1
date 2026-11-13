var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


//misard.com
//https://localhost:7273

app.MapGet("/", () => "API is running");


app.Run();
