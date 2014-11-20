using System;
using System.Runtime.Serialization;

namespace SimpleChat.Api.Event
{
    [DataContract(Name = "UserSubscribed")]
    public class UserSubscribed : IEvent
    {
        [DataMember(Name = "ConnectionId")]
        public Guid ConnectionId { get; protected set; }

        [DataMember(Name = "NickName")]
        public string NickName { get; protected set; }

        public UserSubscribed(Guid connectionId, string nickName)
        {
            ConnectionId = connectionId;
            NickName = nickName;
        }
    }
}