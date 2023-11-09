namespace InkOwl.Interfaces
{
    public interface IChatGptApiService
    {
        Task<string> AskChatGPT(string message);
    }
}
