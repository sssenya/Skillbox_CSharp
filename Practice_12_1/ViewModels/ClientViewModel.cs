using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Practice_12_1.Models;
using Practice_12_1.Commands;
using Practice_12_1.Views;

namespace Practice_12_1.ViewModels
{
    internal class ClientViewModel : BaseViewModel
    {
        private readonly Client _client;
        private readonly MainViewModel _mainVM;

        private readonly BankAccountViewModel<DepositAccount> _depAccountVM;
        private readonly BankAccountViewModel<NonDepositAccount> _nonDepAccountVM;

        private BankAccount _selectedMoveMoneyAccFrom;
        private BankAccount _selectedMoveMoneyAccTo;
        private ClientViewModel _selectedClient;

        private string _moneyToMove;

        public ClientViewModel(Client client, MainViewModel mainVM)
        {
            _client = client;
            _mainVM = mainVM;

            _depAccountVM = new BankAccountViewModel<DepositAccount>(_client.DepositAccount, this);
            _nonDepAccountVM = new BankAccountViewModel<NonDepositAccount>(_client.NonDepositAccount, this);

            _depAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Accounts));
            _nonDepAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Accounts));
            _depAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(OtherClients));

            MoveAccToAccCommand = new RelayCommand(obj => MoveMoneyAccToAcc());
            MoveClientToClientCommand = new RelayCommand(obj => MoveMoneyClientToClient(), obj => CanMoveMoneyClientToClient());
            OpenClientInfoCommand = new RelayCommand(obj => OpenClientInfo());
        }

        public ICommand MoveAccToAccCommand { get; set; }
        public ICommand MoveClientToClientCommand { get; set; }
        public ICommand OpenClientInfoCommand { get; set; }

        public event EventHandler<LogInfoEventArgs> AccountUpdate;

        public Client Client => _client;
        public string FirstName => _client.FirstName;
        public string SecondName => _client.SecondName;
        public string MiddleName => _client.MiddleName;
        public string PassportNumber => _client.PassportNumber;

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

        public List<ClientViewModel> OtherClients => _mainVM
            .ClientsWithDepAccounts
            .Where(x => x.Client.PassportNumber != _client.PassportNumber)
            .ToList();

        public string MoneyToMove
        {
            get => _moneyToMove;
            set => RaiseAndSetIfChanged(ref _moneyToMove, value);
        }

        public BankAccount SelectedMoveMoneyAccFrom
        {
            get => _selectedMoveMoneyAccFrom;
            set => RaiseAndSetIfChanged(ref _selectedMoveMoneyAccFrom, value);
        }

        public BankAccount SelectedMoveMoneyAccTo
        {
            get => _selectedMoveMoneyAccTo;
            set => RaiseAndSetIfChanged(ref _selectedMoveMoneyAccTo, value);
        }

        public ClientViewModel SelectedClient
        {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }

        public Client GetClient()
        {
            return new Client
            {
                FirstName = _client.FirstName,
                SecondName = _client.SecondName,
                MiddleName = _client.MiddleName,
                PassportNumber = _client.PassportNumber,
                DepositAccount = _depAccountVM.GetBankAccount(),
                NonDepositAccount = _nonDepAccountVM.GetBankAccount()
            };
        }

        public void MoveMoneyAccToAcc()
        {
            bool result = double.TryParse(MoneyToMove, out double moneyAmount);
            if(result)
            {
                MoneyMover<BankAccount> moneyMover = new MoneyMover<BankAccount>();

                // Просто проверка работы контравариантности
                IMoneyMover<DepositAccount> moneyMoverDep = moneyMover;

                moneyMover.SetAccounts(SelectedMoveMoneyAccFrom, SelectedMoveMoneyAccTo);
                bool isMoved = moneyMover.MoveMoney(moneyAmount);

                if (isMoved)
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs()
                    {
                        Time = DateTime.Now,
                        AuthorName = "Manager",
                        TransactionType = "Moving money between client's accounts",
                        TransactionSum = moneyAmount
                    };
                    AccountUpdate(this, logInfo);

                    DepAccountVM.UpdateProperties();
                    NonDepAccountVM.UpdateProperties();
                }
            }
        }

        public void MoveMoneyClientToClient()
        {
            bool result = double.TryParse(MoneyToMove, out double moneyAmount);
            if (result)
            {
                MoneyMover<BankAccount> moneyMover = new MoneyMover<BankAccount>();

                moneyMover.SetAccounts(DepAccountVM.BankAccount, SelectedClient.DepAccountVM.BankAccount);
                bool isMoved = moneyMover.MoveMoney(moneyAmount);

                if (isMoved)
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs()
                    {
                        Time = DateTime.Now,
                        AuthorName = "Manager",
                        TransactionType = "Moving money to another client",
                        TransactionSum = moneyAmount
                    };
                    AccountUpdate(this, logInfo);

                    DepAccountVM.UpdateProperties();
                    NonDepAccountVM.UpdateProperties();
                }
            }
        }

        public bool CanMoveMoneyClientToClient()
        {
            if(DepAccountVM.BankAccount == null)
            {
                return false;
            }
            
            return true;
        }

        private void OpenClientInfo()
        {
            ClientInfoViewModel clientInfoVM = new ClientInfoViewModel(this);
            ClientInfoWindow clientInfoWindow = new ClientInfoWindow(clientInfoVM);
            clientInfoWindow.ShowDialog();
        }
    }
}
