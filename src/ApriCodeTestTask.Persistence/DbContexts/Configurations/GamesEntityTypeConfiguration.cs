using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApriCodeTestTask.Persistence.DbContexts.Configurations
{
    public class GamesEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasMany(game => game.Genres)
                .WithMany(genre => genre.Games);

            builder.Property(game => game.Name).IsRequired();
            builder.HasIndex(game => game.Name);
        }
    }
}