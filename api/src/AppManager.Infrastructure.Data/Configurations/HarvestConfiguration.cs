using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppManager.Domain.Entities;

namespace AppManager.Infrastructure.Data.Configurations
{
    public class HarvestConfiguration : IEntityTypeConfiguration<Harvest>
    {
        public void Configure(EntityTypeBuilder<Harvest> builder)
        {
            builder.Property(x => x.GrossWeight).HasColumnType("decimal(18,2)");
            builder.ToTable("Harvest");
        }
    }
}
