var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5500") 
              .AllowAnyHeader()  
              .AllowAnyMethod(); 
    });
});

builder.Services.AddControllers();  

var app = builder.Build();


app.UseCors("AllowFrontend"); 

app.MapControllers();  

app.Run();
