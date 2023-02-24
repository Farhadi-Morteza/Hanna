

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Schedules
{
    public class ProductActivityPlanConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.ProductActivityPlan>
    {
        public void Configure(EntityTypeBuilder<ProductActivityPlan> builder)
        {
            builder
                .HasOne(c => c.ActivityPlan)
                .WithMany(c => c.ProductActivityPlans)
                .HasForeignKey(c => c.ActivityPlanId) 
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
                
                ;
            //builder
            //    .Property(c => c.ForecastProduction)
            //    .HasPrecision(10, 5);
            //builder
            //    .Property(c => c.ForecastSales)
            //    .HasPrecision(10, 5);
            //builder
            //    .Property(c => c.SalePerProductUnit)
            //    .HasPrecision(10, 5);
            //builder
            //    .Property(c => c.PercentageOfSalesShare)
            //    .HasPrecision(4, 2);
        }
    }
}
