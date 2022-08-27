namespace WebGYM.Models.Interfaces
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);
    }
}
