using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public static class UserStore
    {
       
        public static string RegisteredUsername = "admin";
        public static string RegisteredPassword = "ksjvhssudu";

        public static bool Login(string username, string password)
        {
            return username == RegisteredUsername && password == RegisteredPassword;
        }
    }
}
