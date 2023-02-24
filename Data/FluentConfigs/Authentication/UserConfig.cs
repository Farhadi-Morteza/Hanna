
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.FluentConfigs
{
    public class UserConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(p => p.Company)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.CompanyId)
                ;
        }
    }
}
