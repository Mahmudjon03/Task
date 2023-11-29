using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> option):base(option){}
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Shift> Shifts { get; set; }
}