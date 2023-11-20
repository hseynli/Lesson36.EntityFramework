﻿using Libraries;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Məlumatın silinməsi
using (ApplicationContext db = new ApplicationContext())
{
    // Birinci obyekti əldə edirik
    User user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //Obyekti silirik
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // Yenilənmədən sonra məlumatları ekrana çıxarırıq
    Console.WriteLine("\nSilinəndən sonra məlumatlar:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}