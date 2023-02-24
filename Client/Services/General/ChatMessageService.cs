namespace Client.Services
{
    public class ChatMessageService : ServiceBase
    {
        public ChatMessageService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "ChatMessage";
        }

        public async Task<IList<Models.ChatMessage>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.ChatMessage>>();

            return result;
        }

        public async Task<ViewModels.ChatMessageViewModel> PostAsync(ViewModels.ChatMessageViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ChatMessageViewModel, ViewModels.ChatMessageViewModel>(entity);

            return result;
        }
    }
}
