using System;
using System.Runtime.Serialization;

namespace SimpleChat.Api.Event
{
    [DataContract(Name = "UserDto")]
    public class UserDto
    {
        [DataMember(Name = "ConnectionId")]
        public Guid ConnectionId { get; protected set; }

        [DataMember(Name = "NickName")]
        public string NickName { get; protected set; }

        public UserDto(Guid connectionId, string nickName)
        {
            ConnectionId = connectionId;
            NickName = nickName;
        }
    }
}