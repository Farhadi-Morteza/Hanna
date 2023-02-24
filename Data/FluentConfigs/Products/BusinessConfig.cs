

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Products
{
    internal class BusinessConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder
                .HasOne(p => p.PrincipalBusiness)
                .WithMany(p => p.Businesses)
                .HasForeignKey(p => p.PrincipalBusinessId)                
                ;
        }
    }
}
