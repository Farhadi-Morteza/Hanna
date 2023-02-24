
namespace ViewModels
{
    public class ChatMessageViewModel
    {
        public Guid Id { get; set; }
        //=================================================================================================
        //=================================================================================================
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
