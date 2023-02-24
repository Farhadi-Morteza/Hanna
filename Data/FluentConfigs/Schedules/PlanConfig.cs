
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Schedules
{
    internal class PlanConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder
                .HasOne(p => p.Company)
                .WithMany(p => p.Plans)
                .HasForeignKey(p => p.CompanyId)
                ;

            builder
                .HasOne(p => p.Year)
                .WithMany(p => p.Plans)
                .HasForeignKey(p => p.YearId)
                ;
        }
    }
}
