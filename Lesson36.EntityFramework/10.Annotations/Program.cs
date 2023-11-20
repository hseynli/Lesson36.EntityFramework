using Libraries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

Console.WriteLine("\nDone!");

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public ApplicationContext()
    {
        Database.EnsureDeleted();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

public class Employee
{
    [Column("employee_id")]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}