using smtcb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtcb.Services
{
    public class AuthService
    {
        public Func<string, string> HashFunction { get; private set;  }

        public AuthService(UserProvider userProvider) 
        {
            _userProvider = userProvider;
            HashFunction = CreateMD5;
        }

        public AuthService(UserProvider userProvider, Func<string, string> hashFunciton) 
        {
            _userProvider = userProvider;
            HashFunction= hashFunciton;
        }

        private static string CreateMD5(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] outputBytes = md5.ComputeHash(inputBytes);

                string hexString = BitConverter.ToString(outputBytes).Replace("-", "");
                return hexString;
            }   
        }

        public void LoadUserProvider(UserProvider userProvider)
        {
            if (userProvider == null) throw new ArgumentNullException("User provider must not be null");

            _userProvider = userProvider;
        }

        public bool CheckCredentials(string username, string password) 
        {
            var userIndex = _userProvider.UsersIndex;

            User user;

            return userIndex.TryGetValue(username, out user) 
                && user.UserName == username 
                && user.Password == HashFunction(password);
        }

        public bool RegisterUser(string username, string password)
        {
            var userIndex = _userProvider.UsersIndex;

            if (userIndex.ContainsKey(username))
                return false;

            _userProvider.AddUser(new User() { Password = HashFunction(password), UserName = username }) ;

            return true;
        }

        private UserProvider _userProvider;
    }
}
