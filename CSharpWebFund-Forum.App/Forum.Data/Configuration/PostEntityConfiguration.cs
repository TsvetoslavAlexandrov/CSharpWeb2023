namespace Forum.Data.Configuration;

using Models;
using Seeding;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    private readonly PostSeeder postSeeder;

    public PostEntityConfiguration()
    {
        this.postSeeder = new PostSeeder(); 
    }
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(this.postSeeder.GeneratePosts().ToArray());
    }
}