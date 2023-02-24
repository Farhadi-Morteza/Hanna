using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;


namespace Data.FluentConfigs.Products
{
    internal class PrincipalBusinessConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.PrincipalBusiness>
    {
        public void Configure(EntityTypeBuilder<PrincipalBusiness> builder)
        {

        }
    }
}
