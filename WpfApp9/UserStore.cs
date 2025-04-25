using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public static class UserStore
    {
        public static Dictionary<string, string> Users = new();

        public static bool Register(string username, string password)
        {
            if (Users.ContainsKey(username)) return false;
            Users[username] = password;
            return true;
        }

        public static bool Login(string username, string password)
        {
            return Users.TryGetValue(username, out string storedPassword) && storedPassword == password;
        }
    }
}
