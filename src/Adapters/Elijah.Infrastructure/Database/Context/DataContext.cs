using Elijah.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Elijah.Infrastructure.Database.Context;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseInMemoryDatabase(databaseName: "elijah");
    }
    
}