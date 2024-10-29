using WeatheAppDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

/// Register Services
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
