using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppManager.Domain.Entities;

namespace AppManager.Infrastructure.Data.Configurations
{
    public class SpecieConfiguration : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            builder.Property(x => x.PopularName).HasMaxLength(150);
            builder.Property(x => x.ScientificName).HasMaxLength(150);
            builder.ToTable("Specie");
        }
    }
}
