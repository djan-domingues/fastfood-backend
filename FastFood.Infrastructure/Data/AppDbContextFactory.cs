using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FastFood.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Garante que o caminho do appsettings seja relativo ao WebAPI
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../FastFood.WebAPI");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddJsonFile("appsettings.Docker.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Default");

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
