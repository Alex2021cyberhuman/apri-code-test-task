using ApriCodeTestTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApriCodeTestTask.Persistence.DbContexts.Configurations
{
    public class
        DevelopersEntityTypeConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.Property(developer => developer.Name).IsRequired();
            builder.HasIndex(developer => developer.Name);
        }
    }
}