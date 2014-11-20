using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.SignalR;
using SimpleChat.Api.Event;
using SimpleChat.Api.Messaging;

namespace SimpleChat.Api.Hubs
{
    public class ChatHub : Hub
    {
        public void SubscribeUser(string nickName)
        {
            new SignalRPublisher().Publish(new UserSubscribed(nickName));
        }
    }
}