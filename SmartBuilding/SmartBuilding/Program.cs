using Application.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();


// 🟦 חיבור למסד הנתונים
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 שירותים קיימים
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🟨 אם בפיתוח, מציג Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🚀 תשתיות בסיס
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();