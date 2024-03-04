using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ClientByManagerViewModel(Client client)
        {
            _client = client;

            _firstName = client.FirstName;
            _secondName = client.SecondName;
            _middleName = client.MiddleName;
            _phoneNumber = client.PhoneNumber;
            _passportNumber = client.PassportNumber;

        }

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

        public Client GetClient()
        {
            return new Client()
            {
                FirstName = _firstName,
                SecondName = _secondName,
                MiddleName = _middleName,
                PhoneNumber = _phoneNumber,
                PassportNumber = PassportNumber
            };
        }
    }
}
