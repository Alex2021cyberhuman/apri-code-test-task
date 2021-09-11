using ApriCodeTestTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApriCodeTestTask.Persistence.DbContexts.Configurations
{
    public class
        GenressEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(genre => genre.Name).IsRequired();
            builder.HasIndex(genre => genre.Name);
        }
    }
}