using System;
using SimpleChat.Api.Event;
using SimpleChat.Api.Repository;

namespace SimpleChat.Api.Extentions
{
    public static class DtoExtentions
    {
        public static UserDto[] ToDtos(this User[] user)
        {
            return Array.ConvertAll(user, ToDto);
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto(user.ConnectionId, user.NickName);
        }
    }
}