using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GeographicLocationByIp.Domain.Entities;
using GeographicLocationByIp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeographicLocationByIp.Infrastructure.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<GeographicLocation> GeographicLocations {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;

                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;

                        break;
                }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}