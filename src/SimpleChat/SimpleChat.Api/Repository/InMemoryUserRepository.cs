using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleChat.Api.Repository
{
    public class User
    {
        public Guid ConnectionId { get; set; }
        public string NickName { get; set; }
    }

    public class InMemoryUserRepository
    {
        private static readonly Dictionary<Guid, User> UserRepository = new Dictionary<Guid, User>(); 

        public void Add(User user)
        {
            if(!UserRepository.ContainsKey(user.ConnectionId))
                UserRepository.Add(user.ConnectionId, user);
        }

        public void Remove(Guid connectionId)
        {
            if (UserRepository.ContainsKey(connectionId))
                UserRepository.Remove(connectionId);
        }

        public IEnumerable<User> All()
        {
            return UserRepository.Select(c => c.Value);
        }
    }
}