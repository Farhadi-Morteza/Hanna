using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FluentConfigs.Products
{
    internal class ActivityConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder
                .HasOne(p => p.Business)
                .WithMany(p => p.Activities)
                .HasForeignKey(p => p.BusinessId)
                ;

            builder
                .HasOne(c => c.ActivityIndicator)
                .WithMany(c => c.Activities)
                .HasForeignKey(c => c.ActivityIndicatorId)
                ;

            builder
                .HasMany(c => c.Products)
                .WithMany(c => c.Activities)
                ;
        }
    }
}
