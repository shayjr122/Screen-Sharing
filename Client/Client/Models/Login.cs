using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                 _username=value;
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
                _password=value;
            }
        }
        #endregion

        public void StartLogin()
        {
            MessageBox.Show(UserName + "\n" + Password);

  
        }
    }
}
