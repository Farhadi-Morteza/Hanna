using Microsoft.EntityFrameworkCore;

namespace Data.General
{
    public class ChatMessageRepository : Repository<Models.ChatMessage>, IChatMessageRepository
    {
        internal ChatMessageRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Models.ChatMessage>> GetConversationAsync(Guid ContactId)
        {


            var messages =
                await DbSet
                .Where(w => w.FromUserId == ContactId)
                .OrderBy(o => o.CreatedDate)
                .Include(c => c.FromUser)
                .Include(c => c.ToUser)
                .Select(s => new Models.ChatMessage
                {
                    FromUserId = s.FromUserId,
                    Message = s.Message,
                    CreatedDate = s.CreatedDate,
                    Id = s.Id,
                    ToUserId = s.ToUserId,
                    ToUser = s.ToUser,
                    FromUser = s.FromUser,
                })
                .ToListAsync();

            return messages;
        }
    }
}
