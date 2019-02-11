using Client.Commands;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.ViewModels
{
    class LoginViewModel: BaseViewModel
    {
        private ICommand _loginCommand;
        private Login _login;

        public LoginViewModel()
        {
            Login = new Login("shay", "");
            LoginCommand = new MyCommand(func,canExecute);
        }

        #region Properties
        public Login Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand;
            }
            set
            {
                 _loginCommand = value;
            }
        }
        #endregion
        public void func(object parameter)
        {
            PasswordBox password = (PasswordBox)parameter;
            Login.Password = password.Password;
            MessageBox.Show(Login.UserName + "\n" + Login.Password);
        }
    }
}
