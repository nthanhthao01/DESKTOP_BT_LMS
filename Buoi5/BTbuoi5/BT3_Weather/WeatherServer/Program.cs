using WeatherServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin(); 
    });
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Weather Server đang chạy...");

app.MapHub<WeatherHub>("/weatherHub");

Console.WriteLine("Weather Server đang chạy...");

app.Run();
