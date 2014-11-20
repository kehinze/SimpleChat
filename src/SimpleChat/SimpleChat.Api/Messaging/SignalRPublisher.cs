using Microsoft.AspNet.SignalR;
using SimpleChat.Api.Event;

namespace SimpleChat.Api.Messaging
{
    public class SignalRPublisher
    {
        public void Publish(IEvent @event)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<Hubs.ChatHub>();
            
            hub.Clients.All.RaiseEvent(new 
            {
                Type = @event.GetType().Name,
                Body = @event
            });
        }
    }
}