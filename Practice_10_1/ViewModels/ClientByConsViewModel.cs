using Practice_10_1.Commands;
using Practice_10_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice_10_1.ViewModels
{
    internal class ClientByConsViewModel : BaseViewModel, IClientInfo
    {
        private readonly Client _client;
        private readonly EmployeeViewModel _employee;
        private readonly string _firstName;
        private readonly string _secondName;
        private readonly string _middleName;
        private string _phoneNumber;

        public ClientByConsViewModel(Client client, EmployeeViewModel employee)
        {
            _client = client;
            _employee = employee;

            _firstName = client.FirstName;
            _secondName = client.SecondName;
            _middleName = client.MiddleName;
            _phoneNumber = client.PhoneNumber;

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
            set { }
        }
        public string SecondName
        {
            get => _secondName;
            set { }
        }
        public string MiddleName
        {
            get => _middleName;
            set { }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => RaiseAndSetIfChanged(ref _phoneNumber, value);
        }
        public string PassportNumber
        {
            get => "******************";
            set { }
        }

        public bool CanChangeName => false;
        public bool CanChangePassport => false;
        public bool CanChangePhone => true;

        public Client GetUpdatedClient()
        {
            Client newClient = new Client
            {
                FirstName = _firstName,
                SecondName = _secondName,
                MiddleName = _middleName,
                PhoneNumber = _phoneNumber,
                PassportNumber = _client.PassportNumber,
                DataChangeAuthor = _employee.Name,
                DataChangeTime = DateTime.Now
            };

            List<string> fieldsUpdates = new List<string>();
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
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return false;
            }

            return true;
        }

        public void AddNewClient() { }

        public bool CanAddClient()
        {
            return false;
        }

        public virtual void RemoveClient() { }

        public virtual bool CanRemoveClient()
        {
            return false;
        }
    }
}
