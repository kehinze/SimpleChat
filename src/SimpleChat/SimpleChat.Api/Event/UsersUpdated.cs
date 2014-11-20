using System.Runtime.Serialization;

namespace SimpleChat.Api.Event
{
    [DataContract(Name = "UsersUpdated")]
    public class UsersUpdated : IEvent
    {
        [DataMember(Name = "Users")]
        public UserDto[] Users { get; protected set; }
        
        public UsersUpdated(UserDto[] userDtos)
        {
            this.Users = userDtos;
        }
    }
}