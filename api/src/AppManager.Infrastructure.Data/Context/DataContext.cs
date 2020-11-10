using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Infrastructure.Data.Configurations;

namespace AppManager.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<Specie> Species { get; set; }

        public DbSet<Tree> Trees { get; set; }

        public DbSet<Harvest> Harvests { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DataContext()
        {

        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AppManager.db");

            base.OnConfiguring(optionsBuilder);

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new GroupConfiguration());
            builder.ApplyConfiguration(new SpecieConfiguration());
            builder.ApplyConfiguration(new TreeConfiguration());
            builder.ApplyConfiguration(new HarvestConfiguration());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var createdAt = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null && entry.State == EntityState.Added)
                .FirstOrDefault();
            if (createdAt != null)
            {
                createdAt.Property("UpdateAt").CurrentValue = DateTime.Now;
            }


            var updateAt = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("UpdateAt") != null && entry.State == EntityState.Modified)
                .FirstOrDefault();
            if (updateAt != null)
            {
                updateAt.Property("UpdateAt").CurrentValue = DateTime.Now;
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
