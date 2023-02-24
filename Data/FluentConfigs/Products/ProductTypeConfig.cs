

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Products
{
    internal class ProductTypeConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder
                .HasOne(p => p.Culture)
                .WithMany(p => p.ProductTypes)
                .HasForeignKey(p => p.CultrueId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
    ;
        }
    }
}
