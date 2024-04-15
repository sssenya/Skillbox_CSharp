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

        private IBankAccount _selectedAddMoneyAccount;
        private IBankAccount _selectedMoveMoneyAccFrom;
        private IBankAccount _selectedMoveMoneyAccTo;

        private string _moneyToAdd;
        private string _moneyToMove;


        public ClientViewModel(Client client)
        {
            _client = client;
            UpdateAccountsList();

            OpenDepAccCommand = new RelayCommand(obj => OpenNewDepositAccount(), obj => CanOpenDepositAcc());
            OpenNonDepAccCommand = new RelayCommand(obj => OpenNewNonDepositAccount(), obj => CanOpenNonDepositAcc());
            CloseDepAccCommand = new RelayCommand(obj => CloseDepositAccount(), obj => CanCloseDepositAcc());
            CloseNonDepAccCommand = new RelayCommand(obj => CloseNonDepositAccount(), obj => CanCloseNonDepositAcc());

            AddMoneyCommand = new RelayCommand(obj => AddMoneyToAccount());
            MoveBetweenAccsCommand = new RelayCommand(obj => MoveMoney());
        }

        public ICommand OpenDepAccCommand{ get; set; }
        public ICommand OpenNonDepAccCommand{ get; set; }
        public ICommand CloseDepAccCommand { get; set; }
        public ICommand CloseNonDepAccCommand { get; set; }
        public ICommand MoveBetweenAccsCommand { get; set; }
        public ICommand AddMoneyCommand { get; set; }
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

        public string MoneyToAdd
        {
            get => _moneyToAdd;
            set => RaiseAndSetIfChanged(ref _moneyToAdd, value);
        }
        public string MoneyToMove
        {
            get => _moneyToMove;
            set => RaiseAndSetIfChanged(ref _moneyToMove, value);
        }

        public List<BankAccount> Accounts
        {
            get => _accounts;
            set => RaiseAndSetIfChanged(ref _accounts, value);
        }

        public IBankAccount SelectedAddMoneyAccount
        {
            get => _selectedAddMoneyAccount;
            set => RaiseAndSetIfChanged(ref _selectedAddMoneyAccount, value);
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


        public void OpenNewDepositAccount()
        {
            _client.DepositAccount = new DepositAccount();
            UpdateAccountsList();
            OnPropertyChanged(nameof(Accounts));
        }

        public bool CanOpenDepositAcc()
        {
            if(_client.DepositAccount == null)
            {
                return true;
            }
            return false;
        }

        public void OpenNewNonDepositAccount()
        {
            _client.NonDepositAccount = new NonDepositAccount();
            UpdateAccountsList();
            OnPropertyChanged(nameof(Accounts));
        }

        public bool CanOpenNonDepositAcc()
        {
            if (_client.NonDepositAccount == null)
            {
                return true;
            }
            return false;
        }


        public void CloseDepositAccount()
        {
            _client.DepositAccount = null;
            UpdateAccountsList();
            OnPropertyChanged(nameof(Accounts));
        }

        public bool CanCloseDepositAcc()
        {
            if (_client.DepositAccount != null)
            {
                return true;
            }
            return false;
        }

        public void CloseNonDepositAccount()
        {
            _client.NonDepositAccount = null;
            UpdateAccountsList();
            OnPropertyChanged(nameof(Accounts));
        }

        public bool CanCloseNonDepositAcc()
        {
            if (_client.NonDepositAccount != null)
            {
                return true;
            }
            return false;
        }


        public void AddMoneyToAccount()
        {
            bool result = double.TryParse(MoneyToAdd, out double moneyAmount);
            if (result)
            {
                AccountCalculator<IBankAccount>.AddMoney(SelectedAddMoneyAccount, moneyAmount);
                OnPropertyChanged(nameof(DepAccountSum));
                OnPropertyChanged(nameof(NonDepAccountSum));
                MessageBox.Show("Счет пополнен");
            }
        }

        public void MoveMoney()
        {
            bool result = double.TryParse(MoneyToMove, out double moneyAmount);
            if(result)
            {
                AccountCalculator<IBankAccount>.MoveMoney(SelectedMoveMoneyAccFrom, SelectedMoveMoneyAccTo, moneyAmount);
                OnPropertyChanged(nameof(DepAccountSum));
                OnPropertyChanged(nameof(NonDepAccountSum));
                MessageBox.Show("Перевод выполнен");
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
