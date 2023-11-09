namespace InkOwl.Models.ChatGptModels
{
    public class ChatRequest
    {
        public string Model { get; set; }
        public List<ChatGptMessage> Messages { get; set; }
    }
}
