using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Products
{
    internal class ProductIndicatorConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<ProductIndicator>
    {
        public void Configure(EntityTypeBuilder<ProductIndicator> builder)
        {
            builder
                .HasOne(p => p.Metric)
                .WithMany(p => p.ProductIndicators)
                .HasForeignKey(p => p.MetricId)
                ;

            builder
                .Property(p => p.UnitConversion).HasPrecision(10, 9);

        }
    }
}
