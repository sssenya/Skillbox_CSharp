using System.Windows.Input;

using Practice_12_1.Models;
using Practice_12_1.Models.Interfaces;
using Practice_12_1.Commands;
using System.Windows.Documents;
using System.Collections.Generic;
using Practice_12_1.Models.Accounts;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Practice_12_1.ViewModels
{
    internal class ClientViewModel : BaseViewModel
    {
        private readonly Client _client;

        private IBankAccount _selectedMoveMoneyAccFrom;
        private IBankAccount _selectedMoveMoneyAccTo;

        private BankAccountViewModel<DepositAccount> _depAccountVM;
        private BankAccountViewModel<NonDepositAccount> _nonDepAccountVM;

        private string _moneyToMove;

        public ClientViewModel(Client client)
        {
            _client = client;

            _depAccountVM = new BankAccountViewModel<DepositAccount>(_client.DepositAccount);
            _nonDepAccountVM = new BankAccountViewModel<NonDepositAccount>(_client.NonDepositAccount);

            _depAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Accounts));
            _nonDepAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Accounts));

            MoveBetweenAccsCommand = new RelayCommand(obj => MoveMoney());
        }

        public ICommand MoveBetweenAccsCommand { get; set; }
        public ICommand MoveToClient { get; set; }

        public string FirstName => _client.FirstName;
        public string SecondName => _client.SecondName;
        public string MiddleName => _client.MiddleName;

        public BankAccountViewModel<DepositAccount> DepAccountVM => _depAccountVM;
        public BankAccountViewModel<NonDepositAccount> NonDepAccountVM => _nonDepAccountVM;

        public List<BankAccount> Accounts
        {
            get
            {
                List<DepositAccount> depAccounts = new List<DepositAccount>();
                List<NonDepositAccount> nonDepAccounts = new List<NonDepositAccount>();
                if (DepAccountVM.BankAccount != null)
                {
                    depAccounts.Add(DepAccountVM.BankAccount);
                }
                if (NonDepAccountVM.BankAccount != null)
                {
                    nonDepAccounts.Add(NonDepAccountVM.BankAccount);
                }

                IEnumerable<BankAccount> accounts = depAccounts;

                return accounts.Union(nonDepAccounts).ToList();
            }
        }

        public string MoneyToMove
        {
            get => _moneyToMove;
            set => RaiseAndSetIfChanged(ref _moneyToMove, value);
        }

        public IBankAccount SelectedMoveMoneyAccFrom
        {
            get => _selectedMoveMoneyAccFrom;
            set => RaiseAndSetIfChanged(ref _selectedMoveMoneyAccFrom, value);
        }

        public IBankAccount SelectedMoveMoneyAccTo
        {
            get => _selectedMoveMoneyAccTo;
            set => RaiseAndSetIfChanged(ref _selectedMoveMoneyAccTo, value);
        }

        public void MoveMoney()
        {
            bool result = double.TryParse(MoneyToMove, out double moneyAmount);
            if(result)
            {
                SelectedMoveMoneyAccFrom.RemoveMoney(moneyAmount);
                SelectedMoveMoneyAccTo.AddMoney(moneyAmount);
                DepAccountVM.UpdateProperties();
                NonDepAccountVM.UpdateProperties();
                MessageBox.Show("Перевод выполнен");
            }
        }
    }
}
