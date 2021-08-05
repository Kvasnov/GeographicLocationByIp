using GeographicLocationByIp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeographicLocationByIp.Infrastructure.DatabaseContext.Configurations
{
    public class GeographicLocationConfiguration : IEntityTypeConfiguration<GeographicLocation>
    {
        public void Configure(EntityTypeBuilder<GeographicLocation> builder)
        {
            builder.HasKey(location => location.Id);
            builder.HasIndex(location => location.IpAddress).IsUnique();
        }
    }
}