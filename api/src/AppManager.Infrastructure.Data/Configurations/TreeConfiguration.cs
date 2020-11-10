using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppManager.Domain.Entities;

namespace AppManager.Infrastructure.Data.Configurations
{
    public class TreeConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.ToTable("Tree");
        }
    }
}
