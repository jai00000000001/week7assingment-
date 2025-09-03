using Microsoft.EntityFrameworkCore;
using StudentApiEf.Data;
using StudentApiEf.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentDbContext>(opt =>
    opt.UseSqlServer("Server=db;Database=StudentDb;User=sa;Password=Pass@123;TrustServerCertificate=True;"));

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();
