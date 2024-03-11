using System;
using System.Collections.Generic;
using System.Windows.Input;

using Practice_10_1.Commands;

namespace Practice_10_1.ViewModels
{
    internal class ClientByManagerViewModel : BaseViewModel, IClientInfo
    {
        private readonly Client _client;
        private readonly EmployeeViewModel _employee;
        private string _firstName;
        private string _secondName;
        private string _middleName;
        private string _phoneNumber;
        private string _passportNumber;

        public ClientByManagerViewModel(Client client, EmployeeViewModel employee)
        {
            _client = client;
            _employee = employee;

            _firstName = client.FirstName;
            _secondName = client.SecondName;
            _middleName = client.MiddleName;
            _phoneNumber = client.PhoneNumber;
            _passportNumber = client.PassportNumber;

            UpdateClientCommand = new RelayCommand(obj => UpdateClient(), obj => CanUpdateClient());
            AddNewClientCommand = new RelayCommand(obj => AddNewClient(), obj => CanAddClient());
            RemoveClientCommand = new RelayCommand(obj => RemoveClient(), obj => CanRemoveClient());
        }

        public ICommand UpdateClientCommand { get; set; }
        public ICommand AddNewClientCommand { get; set; }
        public ICommand RemoveClientCommand { get; set; }

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
            Client newClient = new Client
            {
                FirstName = _firstName,
                SecondName = _secondName,
                MiddleName = _middleName,
                PhoneNumber = _phoneNumber,
                PassportNumber = _passportNumber,
                DataChangeAuthor = _employee.Name,
                DataChangeTime = DateTime.Now
            };

            List<string> fieldsUpdates = new List<string>();

            if (_client.FirstName != _firstName)
            {
                string changedInfo = $"{nameof(FirstName)} : '{_client.FirstName}' > '{_firstName}'";
                fieldsUpdates.Add(changedInfo);
            }
            if (_client.SecondName != SecondName)
            {
                string changedInfo = $"{nameof(SecondName)} : '{_client.SecondName}' > '{_secondName}'";
                fieldsUpdates.Add(changedInfo);
            }
            if (_client.MiddleName != _middleName)
            {
                string changedInfo = $"{nameof(MiddleName)} : '{_client.MiddleName}' > '{_middleName}'";
                fieldsUpdates.Add(changedInfo);
            }
            if (_client.PassportNumber != _passportNumber)
            {
                string changedInfo = $"{nameof(PassportNumber)} : '{_client.PassportNumber}' > '{_passportNumber}'";
                fieldsUpdates.Add(changedInfo);
            }
            if (_client.PhoneNumber != _phoneNumber)
            {
                string changedInfo = $"{nameof(PhoneNumber)} : '{_client.PhoneNumber}' > '{_phoneNumber}'";
                fieldsUpdates.Add(changedInfo);
            }

            newClient.DataChangeInfo = fieldsUpdates;

            return newClient;
        }

        public void UpdateClient()
        {
            _employee.UpdateClient(this);
        }

        public bool CanUpdateClient()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(SecondName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(MiddleName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PassportNumber))
            {
                return false;
            }

            return true;
        }

        public void AddNewClient()
        {
            _employee.AddNewClient();
        }

        public bool CanAddClient()
        {
            return true;
        }

        public void RemoveClient()
        {
            _employee.RemoveClient(this);
        }

        public bool CanRemoveClient()
        {
            return true;
        }
    }
}
