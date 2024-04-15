using System.Windows.Input;

using Practice_12_1.Models;
using Practice_12_1.Models.Interfaces;
using Practice_12_1.Commands;
using System.Windows.Documents;
using System.Collections.Generic;
using Practice_12_1.Models.Accounts;
using System.Windows;

namespace Practice_12_1.ViewModels
{
    internal class ClientViewModel : BaseViewModel
    {
        private readonly Client _client;
        private List<BankAccount> _accounts;

        private IBankAccount _selectedMoveMoneyAccFrom;
        private IBankAccount _selectedMoveMoneyAccTo;

        private BankAccountViewModel<DepositAccount> _depAccountVM;
        private BankAccountViewModel<NonDepositAccount> _nonDepAccountVM;

        private string _moneyToMove;

        public ClientViewModel(Client client)
        {
            _client = client;
            UpdateAccountsList();

            _depAccountVM = new BankAccountViewModel<DepositAccount>(_client.DepositAccount);
            _nonDepAccountVM = new BankAccountViewModel<NonDepositAccount>(_client.NonDepositAccount);

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
            get => _accounts;
            set => RaiseAndSetIfChanged(ref _accounts, value);
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
            //    AccountCalculator<IBankAccount>.MoveMoney(SelectedMoveMoneyAccFrom, SelectedMoveMoneyAccTo, moneyAmount);
            //    OnPropertyChanged(nameof(DepAccountSum));
            //    OnPropertyChanged(nameof(NonDepAccountSum));
            //    MessageBox.Show("Перевод выполнен");
            }
        }

        private void UpdateAccountsList()
        {
            _accounts = new List<BankAccount>();
            if (_client.DepositAccount != null)
            {
                _accounts.Add(_client.DepositAccount);
            }
            if (_client.NonDepositAccount != null)
            {
                _accounts.Add(_client.NonDepositAccount);
            }
        }
    }
}
