using FastFood.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().OwnsMany(o => o.Items, a =>
        {
            a.WithOwner().HasForeignKey("OrderId");
            a.Property<Guid>("Id");
            a.HasKey("Id");
        });
    }
}
