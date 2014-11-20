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
        private readonly Dictionary<Guid, User> userRepository = new Dictionary<Guid, User>(); 

        public void Add(User user)
        {
            if(!userRepository.ContainsKey(user.ConnectionId))
                userRepository.Add(user.ConnectionId, user);
        }

        public void Remove(Guid connectionId)
        {
            if (userRepository.ContainsKey(connectionId))
                userRepository.Remove(connectionId);
        }

        public IEnumerable<User> All()
        {
            return userRepository.Select(c => c.Value);
        }
    }
}