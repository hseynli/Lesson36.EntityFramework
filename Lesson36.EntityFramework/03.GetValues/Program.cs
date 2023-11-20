using Libraries;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Məlumatların əldə edilməsi
using (ApplicationContext db = new ApplicationContext())
{
    // DB-dan məlumatları əldə edirik və onları ekrana çıxarırıq
    var users = db.Users.ToList();
    Console.WriteLine("Əlavə ediləndən sonra məlumatlar:");

    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}