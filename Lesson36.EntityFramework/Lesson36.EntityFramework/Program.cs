using Libraries;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using (ApplicationContext db = new ApplicationContext())
{
    bool isAvalaible = db.Database.CanConnect();
    
    if (isAvalaible) 
        Console.WriteLine("Verilənlər bazası mövcüddur");
    else Console.WriteLine("Veriləblər bazası mövcüd deyil");
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        //Database.EnsureDeleted(); // Zəmanət veririk ki db silinib
        //Database.EnsureCreated(); // Zəmanət veririk ki db yaranıb
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}