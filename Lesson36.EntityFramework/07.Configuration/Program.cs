using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

ConfigurationBuilder builder = new ConfigurationBuilder();
// Cari kataloqa olan yolu göstərmək
builder.SetBasePath(Directory.GetCurrentDirectory());
// Konfiqurasiyanı appsettings.json faylından əldə etmək
builder.AddJsonFile("appsettings.json");
// Konfiqurasiyanı yaradırıq
IConfigurationRoot config = builder.Build();
// Connection stringi əldə edirik
string connectionString = config.GetConnectionString("DefaultConnection");

DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseSqlServer(connectionString).Options;

using (ApplicationContext db = new ApplicationContext(options))
{
    var users = db.Users.ToList();
    foreach (User user in users)
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
    {        
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}