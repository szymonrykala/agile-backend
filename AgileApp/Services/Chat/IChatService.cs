namespace AgileApp.Services.Chat
{
    public interface IChatService
    {
        public List<string> Load();

        public Task SendMessage(string message);
    }
}
