using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public static class UserStore
    {
<<<<<<< HEAD
       
        public static string RegisteredUsername = "admin";
        public static string RegisteredPassword = "ksjvhssudu";

        public static bool Login(string username, string password)
        {
            return username == RegisteredUsername && password == RegisteredPassword;
=======
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
>>>>>>> 9540fda76e334b2e474cc74b2191f5297fe0c6cb
        }
    }
}
