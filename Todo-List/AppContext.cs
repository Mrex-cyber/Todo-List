using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<Item> Items { get; set; } = null!;
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Item>().HasData(
            new Item("Setup VS") { Id = 1 },
            new Item("Create new project") { Id = 2 }
            );
    }

}
