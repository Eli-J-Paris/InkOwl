namespace InkOwl.Models.ChatGptModels
{
    public class Choice
    {
        public int Index { get; set; }
        public ChatGptMessage Message { get; set; }
        public string FinishReason { get; set; }
    }
}
