using Practice_12_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice_12_1.ViewModels
{
    internal class ClientViewModel
    {
        private readonly Client _client;
        
        public ClientViewModel(Client client)
        {
            _client = client;
        }

        public ICommand OpenAccount { get; set; }
        public ICommand CloseAccount { get; set; }
        public ICommand MoveBetweenAccounts { get; set; }
        public ICommand PutMoney { get; set; }
        public ICommand MoveToClient { get; set; }

        public string FirstName => _client.FirstName;
        public string SecondName => _client.SecondName;
        public string MiddleName => _client.MiddleName;

        public string DepAccountStatus => _client.DepositAccount == null ? "Счет не открыт" : "Открыт";
        public double DepAccountSum => _client.DepositAccount == null ? 0 : _client.DepositAccount.Balance;
        public DateTime DepAccountDate { get; set; }
        public string DepAccountPercent { get; set; }

        public string NonDepAccountStatus { get; set; }
        public double NonDepAccountSum { get; set; }
        public DateTime NonDepAccountDate { get; set; }
        public string NonDepAccountPercent { get; set; }
    }
}
