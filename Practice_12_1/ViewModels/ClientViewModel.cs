using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Practice_12_1.Models;

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

        public string DepAccountStatus => _client.DepositAccount == null ? "Не открыт" : "Открыт";
        public double DepAccountSum => _client.DepositAccount == null ? 0 : _client.DepositAccount.Balance;
        public string DepAccountDate => _client.DepositAccount == null ? "" : _client.DepositAccount.OpeningDate.ToShortDateString();
        public double DepAccountPercent => _client.DepositAccount == null ? 0 : _client.DepositAccount.Percent;

        public string NonDepAccountStatus => _client.NonDepositAccount == null ? "Не открыт" : "Открыт";
        public double NonDepAccountSum => _client.NonDepositAccount == null ? 0 : _client.NonDepositAccount.Balance;
        public string NonDepAccountDate => _client.NonDepositAccount == null ? "" : _client.NonDepositAccount.OpeningDate.ToShortDateString();
        public double NonDepAccountPercent => _client.NonDepositAccount == null ? 0 : _client.NonDepositAccount.Percent;
    }
}
