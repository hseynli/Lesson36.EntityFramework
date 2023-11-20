using Libraries;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using (ApplicationContext db = new ApplicationContext())
{
    User user1 = new User { Name = "Tom2", Age = 33 };
    User user2 = new User { Name = "Alice2", Age = 26 };

    db.Users.Add(user1);
    db.Users.Add(user2);
    db.SaveChanges();

    var users = db.Users.ToList();
    Console.WriteLine("İstifadəçilərin siyahısı:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}