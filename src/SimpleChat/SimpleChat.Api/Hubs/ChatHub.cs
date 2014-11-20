using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SimpleChat.Api.Event;
using SimpleChat.Api.Extentions;
using SimpleChat.Api.Messaging;
using SimpleChat.Api.Repository;

namespace SimpleChat.Api.Hubs
{
    public class ChatHub : Hub
    {
        public void SubscribeUser(string nickName)
        {
            var signalRPublisher = new SignalRPublisher();
            var inMemoryRepository = new InMemoryUserRepository();

            inMemoryRepository.Add(new User
            {
                ConnectionId = Guid.Parse(Context.ConnectionId),
                NickName = nickName
            });

            signalRPublisher.Publish(new UserSubscribed(nickName));

            var users = inMemoryRepository.All().ToArray();

            var userDtos = users.ToDtos();

            signalRPublisher.Publish(new UsersUpdated(userDtos));
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var inMemoryRepository = new InMemoryUserRepository();

            inMemoryRepository.Remove(Guid.Parse(Context.ConnectionId));

            return base.OnDisconnected(stopCalled);
        }
    }
}