using System.Runtime.Serialization;

namespace SimpleChat.Api.Event
{
    [DataContract(Name = "UserSubscribed")]
    public class UserSubscribed : IEvent
    {
        [DataMember(Name = "NickName")]
        public string NickName { get; protected set; }

        public UserSubscribed(string nickName)
        {
            NickName = nickName;
        }
    }
}