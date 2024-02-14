using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ConsoleApp2;

class AppDbContext : DbContext
{
    public AppDbContext() : base()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=EFTest;Trusted_Connection=True;TrustServerCertificate=True;");
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(new User
            {
                Id = -1,
                FirstName = "Test",
                LastName = "Testov"
            }, new User
            {
                Id = -2,
                FirstName = "Free",
                LastName = "Freerov"
            });
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasData(new Account
            {
                Id = -1,
                Login = "SuperTest",
                UserId = -1
            }, new Account
            {
                Id = -2,
                Login = "MiniTest",
                UserId = -1
            });
        });
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;
}