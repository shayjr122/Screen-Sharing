using Client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    class MainWindowViewModel:BaseViewModel
    {
        private ICommand _close;
        private ICommand _maximize;
        private ICommand _minimize;
        private WindowState _windowState;

        public MainWindowViewModel()
        {
            Close = new MyCommand(OnClose, canExecute);
            Maximize = new MyCommand(OnMaximized, canExecute);
            Minimize = new MyCommand(OnMinimize, canExecute);

        }


        #region Properties
        public WindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                _windowState = value;
                OnPropertyChanged("WindowState");
            }
        }
        public ICommand Close
        {
            get
            {
                return _close;
            }
            set
            {
                _close = value;
            }
        }
        public ICommand Maximize
        {
            get
            {
                return _maximize;
            }
            set
            {
                _maximize = value;
            }
        }
        public ICommand Minimize
        {
            get
            {
                return _minimize;
            }
            set
            {
                _minimize = value;
            }
        }
        #endregion

        public void OnClose(object parameter)
        {
            Application.Current.Shutdown();
        }

        public void OnMinimize(object parameter)
        {
            WindowState = WindowState.Minimized;
        }

        public void OnMaximized(object parameter)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }

        }
    }
}
