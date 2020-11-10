using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppManager.Domain.Entities;

namespace AppManager.Infrastructure.Data.Configurations
{
    public class HarvestConfiguration : IEntityTypeConfiguration<Harvest>
    {
        public void Configure(EntityTypeBuilder<Harvest> builder)
        { 
            builder.ToTable("Harvest");
        }
    }
}
