using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region INotifyPropertyChanged Members

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        /// <summary>
        ///default ICommand canExecute fanction 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected bool canExecute(object param)
        {
            return true;
        }


    }
}
