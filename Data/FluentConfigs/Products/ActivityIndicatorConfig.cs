using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Products
{
    internal class ActivityIndicatorConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<ActivityIndicator>
    {
        public void Configure(EntityTypeBuilder<ActivityIndicator> builder)
        {
            builder
                .HasOne(p => p.Metric)
                .WithMany(p => p.ActivityIndicators)
                .HasForeignKey(p => p.MetricId)
                ;
        }
    }
}
