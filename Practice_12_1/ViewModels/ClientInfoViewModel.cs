using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Practice_12_1.Commands;
using Practice_12_1.Models;

namespace Practice_12_1.ViewModels
{
    internal class ClientInfoViewModel : BaseViewModel
    {
        private readonly ClientViewModel _clientVM;

        private string _firstName;
        private string _secondName;
        private string _middleName;
        private string _passportNumber;

        public ClientInfoViewModel(ClientViewModel clientVM) 
        {
            _clientVM = clientVM;

            _firstName = clientVM.FirstName;
            _secondName = clientVM.SecondName;
            _middleName = clientVM.MiddleName;
            _passportNumber = clientVM.PassportNumber;

            UpdateInfoCommand = new RelayCommand(obj => UpdateInfo());
        }

        public ICommand UpdateInfoCommand { get; set; }

        

        public string FirstName
        {
            get => _firstName;
            set => RaiseAndSetIfChanged(ref _firstName, value);
        }

        public string SecondName
        {
            get => _secondName;
            set => RaiseAndSetIfChanged(ref _secondName, value);
        }

        public string MiddleName
        {
            get => _middleName;
            set => RaiseAndSetIfChanged(ref _middleName, value);
        }

        public string PassportNumber
        {
            get => _passportNumber;
            set => RaiseAndSetIfChanged(ref _passportNumber, value);
        }

        public void UpdateInfo()
        {
            _clientVM.Client.UpdateInfo(FirstName, SecondName, MiddleName, PassportNumber);
        }
    }
}
