using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ChatMessageController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ChatMessageController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.ChatMessage>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ChatMessageRepository.GetConversationAsync(UserId);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(value: result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ViewModels.ChatMessageViewModel>> PostAsync(ViewModels.ChatMessageViewModel message)
        {
            if (message is null)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }

            try
            {
                var from =
                    UnitOfWork.UserRepository.GetById(message.FromUserId);
                var to =
                    UnitOfWork.UserRepository.GetById(message.ToUserId);

                var NewEntity =
                    new Models.ChatMessage
                    {
                        FromUserId = UserId,
                        CreatedDate = DateTime.Now,
                        ToUserId = message.ToUserId,
                        Message = message.Message,
                        FromUser = from,
                        ToUser = to,
                    };
                await UnitOfWork.ChatMessageRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }
    }
}
