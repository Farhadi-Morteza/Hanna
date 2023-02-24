using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs.Products
{
    internal class ProductConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.ProductType)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.ProductTypeId)
                ;

            //builder
            //    .HasMany(p => p.Activities)
            //    .WithMany(p => p.Products)
            //    ;

            builder
                .HasOne(p => p.ProductIndicator)
                .WithMany(P => P.Products)
                .HasForeignKey(p => p.ProductIndicatorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
                ;
        }
    }
}
