using Microsoft.EntityFrameworkCore;
namespace BlogBlazor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.UserName).IsUnique();
        });
    }

    public DbSet<User> Users { get; set; }
}
