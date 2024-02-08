using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal class ClientInfoViewModel : BaseViewModel
    {
        private readonly Client _client;
        private string _firstName;
        private string _secondName;
        private string _middleName;
        private string _phoneNumber;
        private string _passportNumber;

        public ClientInfoViewModel(Client client)
        {
            _client = client;

            _firstName = client.FirstName;
            _secondName = client.SecondName;
            _middleName = client.MiddleName;
            _phoneNumber = client.PhoneNumber;
            if (!string.IsNullOrEmpty(client.PassportNumber))
            {
                _passportNumber = "******************";
            }
            else
            {
                _passportNumber = "";
            }
        }

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
            get => _passportNumber;
            set { }
        }

        public Client GetClient()
        {
            return new Client()
            {
                FirstName = _firstName,
                SecondName = _secondName,
                MiddleName = _middleName,
                PhoneNumber = _phoneNumber,
                PassportNumber = _client.PassportNumber
            };
        }
    }
}
