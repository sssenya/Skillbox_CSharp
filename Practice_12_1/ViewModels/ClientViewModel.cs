using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Practice_12_1.Models;
using Practice_12_1.Commands;

namespace Practice_12_1.ViewModels
{
    internal class ClientViewModel : BaseViewModel
    {
        private readonly Client _client;

        private BankAccount _selectedMoveMoneyAccFrom;
        private BankAccount _selectedMoveMoneyAccTo;
        private ClientViewModel _selectedClient;

        private BankAccountViewModel<DepositAccount> _depAccountVM;
        private BankAccountViewModel<NonDepositAccount> _nonDepAccountVM;

        private string _moneyToMove;

        private MainViewModel _mainVM;

        public ClientViewModel(Client client, MainViewModel mainVM)
        {
            _client = client;
            _mainVM = mainVM;

            _depAccountVM = new BankAccountViewModel<DepositAccount>(_client.DepositAccount);
            _nonDepAccountVM = new BankAccountViewModel<NonDepositAccount>(_client.NonDepositAccount);

            _depAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Accounts));
            _nonDepAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Accounts));
            _depAccountVM.PropertyChanged += (s, e) => OnPropertyChanged(nameof(OtherClients));

            MoveAccToAccCommand = new RelayCommand(obj => MoveMoneyAccToAcc());
            MoveClientToClientCommand = new RelayCommand(obj => MoveMoneyClientToClient());
        }

        public ICommand MoveAccToAccCommand { get; set; }
        public ICommand MoveClientToClientCommand { get; set; }

        public Client Client => _client;
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

        public void MoveMoneyAccToAcc()
        {
            bool result = double.TryParse(MoneyToMove, out double moneyAmount);
            if(result)
            {
                MoneyMover<BankAccount> moneyMover = new MoneyMover<BankAccount>();

                // Просто проверка работы контравариантности
                IMoneyMover<DepositAccount> moneyMoverDep = moneyMover;

                moneyMover.SetAccounts(SelectedMoveMoneyAccFrom, SelectedMoveMoneyAccTo);
                moneyMover.MoveMoney(moneyAmount);

                DepAccountVM.UpdateProperties();
                NonDepAccountVM.UpdateProperties();
            }
        }

        public void MoveMoneyClientToClient()
        {
            bool result = double.TryParse(MoneyToMove, out double moneyAmount);
            if (result)
            {
                MoneyMover<BankAccount> moneyMover = new MoneyMover<BankAccount>();

                moneyMover.SetAccounts(DepAccountVM.BankAccount, SelectedClient.DepAccountVM.BankAccount);
                moneyMover.MoveMoney(moneyAmount);

                DepAccountVM.UpdateProperties();
                NonDepAccountVM.UpdateProperties();
            }
        }
    }
}
