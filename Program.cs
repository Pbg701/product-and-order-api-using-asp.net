// // // // var builder = WebApplication.CreateBuilder(args);

// // // // // Add services to the container.
// // // // // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// // // // builder.Services.AddOpenApi();

// // // // var app = builder.Build();

// // // // // Configure the HTTP request pipeline.
// // // // if (app.Environment.IsDevelopment())
// // // // {
// // // //     app.MapOpenApi();
// // // // }

// // // // app.UseHttpsRedirection();

// // // // var summaries = new[]
// // // // {
// // // //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// // // // };

// // // // app.MapGet("/weatherforecast", () =>
// // // // {
// // // //     var forecast =  Enumerable.Range(1, 5).Select(index =>
// // // //         new WeatherForecast
// // // //         (
// // // //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// // // //             Random.Shared.Next(-20, 55),
// // // //             summaries[Random.Shared.Next(summaries.Length)]
// // // //         ))
// // // //         .ToArray();
// // // //     return forecast;
// // // // })
// // // // .WithName("GetWeatherForecast");

// // // // app.Run();

// // // // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// // // // {
// // // //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// // // // }
// // // using MyApi.Data;
// // // using Microsoft.EntityFrameworkCore;
// // // var builder = WebApplication.CreateBuilder(args);
// // // using MyApi.
// // // // ADD CONTROLLERS
// // // builder.Services.AddControllers();
// // // builder.Services.AddDbContext<AppDbContext>(options =>
// // //     options.UseSqlServer("your_connection_string"));
// // // // ADD SWAGGER
// // // builder.Services.AddEndpointsApiExplorer();
// // // builder.Services.AddSwaggerGen();
// // // builder.Services.AddScoped<Repository<Product>>();
// // // var app = builder.Build();

// // // // ENABLE SWAGGER
// // // app.UseSwagger();
// // // app.UseSwaggerUI();

// // // app.UseHttpsRedirection();

// // // // MAP CONTROLLERS
// // // app.MapControllers();

// // // app.Run();
// // using Microsoft.EntityFrameworkCore;
// // using MyApi.Data;
// // using MyApi.Repository;

// // var builder = WebApplication.CreateBuilder(args);

// // // Add services
// // builder.Services.AddControllers();

// // builder.Services.AddDbContext<AppDbContext>(options =>
// //     options.UseSqlServer("your_connection_string"));

// // // ✅ FIXED DI
// // builder.Services.AddScoped<IRepository, Repository>();

// // // Swagger
// // builder.Services.AddEndpointsApiExplorer();
// // builder.Services.AddSwaggerGen();

// // var app = builder.Build();

// // // Middleware
// // app.UseSwagger();
// // app.UseSwaggerUI();

// // app.UseHttpsRedirection();
// // app.MapControllers();

// // app.Run();
// using Microsoft.EntityFrameworkCore;
// using MyApi.Data;
// using MyApi.Repository;

// var builder = WebApplication.CreateBuilder(args);

// // ✅ Add Controllers
// builder.Services.AddControllers();

// // ✅ MySQL Connection (FIXED)
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(
//         "server=localhost;port=3306;database=MyApiDb;user=root;password=Pbg@2003;",
//         ServerVersion.AutoDetect("server=localhost;port=3306;database=MyApiDb;user=root;password=Pbg@2003;")
//     ));
// var conn = builder.Configuration.GetConnectionString("DefaultConnection");
// Console.WriteLine("CONNECTION STRING: " + conn);
// // ✅ Dependency Injection
// builder.Services.AddScoped<IRepository, Repository>();

// // ✅ Swagger
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // ✅ Middleware
// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseHttpsRedirection();
// app.MapControllers();

// app.Run();
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// ✅ १. Connection String 'appsettings.json' मधून वाचणे
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ २. MySQL Database Config (Pomelo.EntityFrameworkCore.MySql आवश्यक)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ✅ ३. Dependency Injection (Interface आणि Class मॅपिंग)
builder.Services.AddScoped<IRepository, Repository>();

// ✅ ४. Controllers आणि Swagger 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// ✅ ५. Middleware Pipeline
// नेहमी Swagger इनेबल ठेवण्यासाठी (Development मोड बाहेरही)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();