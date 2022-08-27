using Microsoft.AspNetCore.SignalR;
using WebGYM.Models.Interfaces;

namespace WebGYM.Models
{
    public class MessageHub : Hub <IMessageHubClient>
    {
        public async Task SendOffersToUser(List <string> message)
        {
            await Clients.All.SendOffersToUser (message);
        }
    }
}
