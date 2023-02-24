using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FluentConfigs
{
    public class CompanyConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.Company>
    {
        public void Configure(EntityTypeBuilder<Models.Company> builder)
        {
            //builder
            //    .HasOne(p => p.Address)
            //    .WithOne(p => p.Company)
            //    .HasForeignKey<Models.Company>(p => p.AddressId)
            //    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
            //    ;
            builder
                .HasOne(p => p.CompanyCategory)
                .WithMany(p => p.Companies)
                .HasForeignKey(p => p.CompanyCategoryId)
                ;
            //builder
            //    .HasOne(p => p.CompanyType)
            //    .WithMany(p => p.Companies)
            //    .HasForeignKey(p => p.CompanyTypeId)
            //    ;

            builder
                .HasOne(p => p.CompanyParent)
                .WithMany(p => p.CompanyChild)
                .HasForeignKey(p => p.CompanyParentId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
                ;



        }
    }
}
