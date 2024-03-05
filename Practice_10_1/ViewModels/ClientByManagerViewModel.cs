using Practice_10_1.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice_10_1.ViewModels
{
    internal class ClientByManagerViewModel : BaseViewModel, IClientInfo
    {
        private readonly Client _client;
        private string _firstName;
        private string _secondName;
        private string _middleName;
        private string _phoneNumber;
        private string _passportNumber;
        private EmployeeViewModel _employee;

        public ClientByManagerViewModel(Client client, EmployeeViewModel employee)
        {
            _client = client;
            _employee = employee;

            _firstName = client.FirstName;
            _secondName = client.SecondName;
            _middleName = client.MiddleName;
            _phoneNumber = client.PhoneNumber;
            _passportNumber = client.PassportNumber;

            UpdateClientCommand = new RelayCommand(obj => UpdateClient(), obj => CanExecute());
        }

        public ICommand UpdateClientCommand { get; set; }

        public Client Client => _client;
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

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => RaiseAndSetIfChanged(ref _phoneNumber, value);
        }

        public string PassportNumber
        {
            get => _passportNumber;
            set => RaiseAndSetIfChanged(ref _passportNumber, value);
        }

        public bool CanChangeName => true;
        public bool CanChangePassport => true;
        public bool CanChangePhone => true;

        public Client GetUpdatedClient()
        {
            return new Client()
            {
                FirstName = _firstName,
                SecondName = _secondName,
                MiddleName = _middleName,
                PhoneNumber = _phoneNumber,
                PassportNumber = _passportNumber
            };
        }

        public void UpdateClient()
        {
            _employee.UpdateClient(this);
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
