using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FluentConfigs.General
{
    internal class ChatMessageConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.ChatMessage>
    {
        public void Configure(EntityTypeBuilder<Models.ChatMessage> builder)
        {
            builder
                .HasOne(p => p.FromUser)
                .WithMany(p => p.ChatMessagesFromUsers)
                .HasForeignKey(p => p.FromUserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);

            builder
                .HasOne(p => p.ToUser)
                .WithMany(p => p.ChatMessagesToUsers)
                .HasForeignKey(p => p.ToUserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
