using Practice_12_1.Commands;
using Practice_12_1.Models;
using Practice_12_1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Practice_12_1.ViewModels
{
    internal class BankAccountViewModel<T> : BaseViewModel
        where T : IBankAccount, new()
    {
        private T _bankAccount;

        private string _moneyToAdd;

        public BankAccountViewModel(T bankAccount)
        {
            _bankAccount = bankAccount;

            OpeAccCommand = new RelayCommand(obj => OpenAccount(), obj => CanOpenAcc());
            CloseAccCommand = new RelayCommand(obj => CloseAccount(), obj => CanCloseAcc());
            AddMoneyCommand = new RelayCommand(obj => AddMoney(), obj => CanCloseAcc());
        }

        public ICommand OpeAccCommand { get; set; }
        public ICommand CloseAccCommand { get; set; }
        public ICommand AddMoneyCommand { get; set; }

        public T BankAccount
        {
            get => _bankAccount;
            set => RaiseAndSetIfChanged(ref _bankAccount, value);
        }

        public string AccountStatus => _bankAccount == null ? "Не открыт" : "Открыт";
        public double AccountSum => _bankAccount == null ? 0 : _bankAccount.Balance;
        public string AccountDate => _bankAccount == null ? "" : _bankAccount.OpeningDate.ToShortDateString();
        public double AccountPercent => _bankAccount == null ? 0 : _bankAccount.Percent;

        public string MoneyToAdd
        {
            get => _moneyToAdd;
            set => RaiseAndSetIfChanged(ref _moneyToAdd, value);
        }

        public void AddMoney()
        {
            bool result = double.TryParse(MoneyToAdd, out double moneyAmount);
            if (result)
            {
                _bankAccount.Balance += moneyAmount;
                OnPropertyChanged(nameof(AccountSum));
                MessageBox.Show("Счет пополнен");
            }
        }

        public void RemoveMoney(double sum)
        {
            if (_bankAccount.Balance >= sum)
            {
                _bankAccount.Balance -= sum;
            }
        }

        public void OpenAccount()
        {
            _bankAccount = new T();
            UpdateProperties();
        }

        public bool CanOpenAcc()
        {
            if (_bankAccount == null)
            {
                return true;
            }
            return false;
        }

        public void CloseAccount()
        {
            _bankAccount = default;
            UpdateProperties();
        }

        public bool CanCloseAcc()
        {
            if (_bankAccount != null)
            {
                return true;
            }
            return false;
        }

        private void UpdateProperties()
        {
            OnPropertyChanged(nameof(AccountStatus));
            OnPropertyChanged(nameof(AccountSum));
            OnPropertyChanged(nameof(AccountDate));
            OnPropertyChanged(nameof(AccountPercent));
        }
    }
}
