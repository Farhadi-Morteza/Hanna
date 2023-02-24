using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs
{
    public class CompanyCategoryConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.CompanyCategory>
    {
        public void Configure(EntityTypeBuilder<CompanyCategory> builder)
        {
            //builder
            //    .HasOne(p => p.Culture)
            //    .WithMany(p => p.CompanyCategories)
            //    .HasForeignKey(p => p.CultrueId)
            //    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
            //    //.IsRequired(required: false)
            //    ;
        }
    }
}
