using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
    public interface IChatMessageRepository : IRepositoryBase<Models.ChatMessage>
    {
        Task<List<ChatMessage>> GetConversationAsync(Guid ContactId);
    }
}
