using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class Login
    {
        private string _username;
        private string _password;

        public Login(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        #region Properties
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                value = _username;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                value = _password;
            }
        }
        #endregion
    }
}
