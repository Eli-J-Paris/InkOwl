namespace InkOwl.Models
{
    public class ChatBotMessageTracker
    {
        public int Id { get; set; }
        public List<Message>? UsersMessages { get; set; }
        public List<Message>? ChatBotMessages { get; set; }
    }
}
