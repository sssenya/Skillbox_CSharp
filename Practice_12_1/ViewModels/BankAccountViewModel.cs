using System;
using System.Windows.Input;

using Practice_12_1.Commands;
using Practice_12_1.Models;


namespace Practice_12_1.ViewModels
{
    internal class BankAccountViewModel<T> : BaseViewModel
        where T : IBankAccount, new()
    {
        private T _bankAccount;
        private readonly ClientViewModel _accountOwner;

        private string _moneyToAdd;

        public BankAccountViewModel(T bankAccount, ClientViewModel accountOwner)
        {
            _bankAccount = bankAccount;
            _accountOwner = accountOwner;

            OpeAccCommand = new RelayCommand(obj => OpenAccount(), obj => CanOpenAcc());
            CloseAccCommand = new RelayCommand(obj => CloseAccount(), obj => CanCloseAcc());
            AddMoneyCommand = new RelayCommand(obj => AddMoney(MoneyToAdd), obj => CanCloseAcc());
        }

        public ICommand OpeAccCommand { get; set; }
        public ICommand CloseAccCommand { get; set; }
        public ICommand AddMoneyCommand { get; set; }

        public event EventHandler<LogInfoEventArgs> AccountUpdate;

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

        public void AddMoney(string sum)
        {
            bool result = double.TryParse(sum, out double moneyAmount);
            if (result)
            {
                _bankAccount.AddMoney(moneyAmount);

                LogInfoEventArgs logInfo = new LogInfoEventArgs()
                {
                    Time = DateTime.Now,
                    AuthorName = "Manager",
                    TransactionType = "Account replenishment",
                    TransactionSum = moneyAmount
                };
                AccountUpdate(_accountOwner, logInfo);
            }
        }

        public void OpenAccount()
        {
            _bankAccount = new T();

            LogInfoEventArgs logInfo = new LogInfoEventArgs()
            {
                Time = DateTime.Now,
                AuthorName = "Manager",
                TransactionType = "Account opening",
                TransactionSum = 0
            };
            AccountUpdate(_accountOwner, logInfo);
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
            LogInfoEventArgs logInfo = new LogInfoEventArgs()
            {
                Time = DateTime.Now,
                AuthorName = "Manager",
                TransactionType = "Account closing",
                TransactionSum = 0
            };
            AccountUpdate(_accountOwner, logInfo);
        }

        public bool CanCloseAcc()
        {
            if (_bankAccount != null)
            {
                return true;
            }
            return false;
        }   

        public T GetBankAccount()
        {
            return _bankAccount;
        }
    }
}
