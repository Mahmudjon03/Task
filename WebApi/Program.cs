using Domain.DTOs.ShiftDto;
using Infrastructure.Data;
using Infrastructure.Services.ShiftServices;
using Infrastructure.Servises;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(c => c.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(typeof(Infrastructure.Mapper.AutoMapper));
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IShiftService,ShiftService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
