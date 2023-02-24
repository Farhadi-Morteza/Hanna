
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Schedules
{
    public class ActivityPlanConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.ActivityPlan>
    {
        public void Configure(EntityTypeBuilder<ActivityPlan> builder)
        {
            builder
                .HasOne(c => c.Plan)
                .WithMany(c => c.ActivityPlans)
                .HasForeignKey(c => c.PlanId)
                ;
            builder
                .HasOne(c => c.Activity)
                .WithMany(c => c.ActivityPlans)
                .HasForeignKey(c => c.ActivityId)
                ;
            builder
                .HasOne(c => c.BusinessType)
                .WithMany(c => c.ActivityPlans)
                .HasForeignKey(c => c.BusinessTypeId)
                ;

            //builder
            //    .Property(c => c.ForecastFinalPrice)                
            //    .HasPrecision(10, 5);
            //builder
            //    .Property(c => c.ForecastLevel)
            //    .HasPrecision(10, 5);
            //builder
            //    .Property(c => c.Capacitylevel)
            //    .HasPrecision(10, 5);
        }
    }
}
