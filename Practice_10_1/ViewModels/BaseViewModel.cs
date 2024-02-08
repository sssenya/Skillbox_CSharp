using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaiseAndSetIfChanged<TRet>(ref TRet backingField, TRet newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<TRet>.Default.Equals(backingField, newValue))
            {
                backingField = newValue;
                RaisePropertyChanged(propertyName);
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
