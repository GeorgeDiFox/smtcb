using smtcb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtcb.Services
{
    public class UserProvider
    {
        public UserProvider()
        {
            _users = new List<User>();
            _usersIndex = new Dictionary<string, User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.AsEnumerable<User>();
        }

        private int GenId()
        {
            return 1;
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException("User value cannot be null");

            if (UsersIndex.ContainsKey(user.UserName)) throw new InvalidOperationException("User to be added already exists");

            user.Id = GenId();

            _users.Add(user);

            UpdateIndex(user);
        }

        public Dictionary<string, User> GetUserIndex()
        {
            return UsersIndex;
        }

        public void UpdateIndex(User user) 
        {
            _usersIndex.Add(user.UserName, user);
        }

        public List<User> Users { get => _users; }

        private List<User> _users;
        
        public Dictionary<string, User> UsersIndex { get => _usersIndex; }

        private Dictionary<string, User> _usersIndex;
    }
}
