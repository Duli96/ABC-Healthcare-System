using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<UserServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<DataSeeder>();


builder.Services.AddScoped<IUserService, UserServiceImpl>();

// Run Data Seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<DataSeeder>();
    seeder.Seed();
}

// Add OpenAPI / Swagger generation services
builder.Services.AddEndpointsApiExplorer(); // Replaces AddOpenApi
builder.Services.AddSwaggerGen(); // Swagger UI generator

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Replaces MapOpenApi
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
