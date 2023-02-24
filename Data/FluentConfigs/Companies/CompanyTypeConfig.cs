using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FluentConfigs
{
    public class CompanyTypeConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.CompanyType>
    {
        public void Configure(EntityTypeBuilder<CompanyType> builder)
        {
            //builder
            //    .HasOne(p => p.Culture)
            //    .WithMany(p => p.CompanyTypes)
            //    .HasForeignKey(p => p.CultrueId)
            //    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
            //    ;
        }
    }
}
