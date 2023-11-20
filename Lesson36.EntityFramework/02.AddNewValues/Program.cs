﻿using Libraries;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };

    // Yeni məlumatın əlavə edilməsi
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
}

Console.WriteLine("\nDone!");

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
    public string Name { get; set; }
    public int Age { get; set; }
}