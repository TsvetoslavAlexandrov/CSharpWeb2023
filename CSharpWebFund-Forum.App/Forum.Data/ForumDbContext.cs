namespace Forum.Data;

using Configuration;
using Models;

using Microsoft.EntityFrameworkCore;
public class ForumDbContext : DbContext
{
    public ForumDbContext(DbContextOptions options)
        :base(options)
    {
            
    }

    public DbSet<Post> Posts { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostEntityConfiguration());


        base.OnModelCreating(modelBuilder); 
    }
}