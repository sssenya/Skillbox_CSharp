using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal class ClientInfoViewModel
    {
        private readonly Client _client;

        public ClientInfoViewModel(Client client)
        {
            _client = client;
        }

        public string FirstName
        {
            get => _client.FirstName;
            set { }
        } 
        public string SecondName
        {
            get => _client.SecondName;
            set { }
        }

        public string MiddleName
        {
            get => _client.MiddleName;
            set { }
        }

        public string PhoneNumber
        {
            get => _client.PhoneNumber;
            set { }
        }

        public string PassportNumber
        {
            get => _client.PassportNumber;
            set { }
        }
    }
}
