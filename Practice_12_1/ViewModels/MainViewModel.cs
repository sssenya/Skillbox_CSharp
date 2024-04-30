using Microsoft.Toolkit.Uwp.Notifications;
using Practice_12_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ClientViewModel> _clients;
        private ClientViewModel _selectedClient;

        private Repository _repository;

        public MainViewModel()
        {
            _repository = new Repository();

            _clients = new ObservableCollection<ClientViewModel>(_repository
                                                                    .GetClients()
                                                                    .Select(x => new ClientViewModel(x, this)));

            foreach(var client in _clients)
            {
                client.AccountUpdate += Client_CreateLog;
                client.DepAccountVM.AccountUpdate += Client_CreateLog;
                client.NonDepAccountVM.AccountUpdate += Client_CreateLog;

                client.AccountUpdate += Client_UpdateDB;
                client.DepAccountVM.AccountUpdate += Client_UpdateDB;
                client.NonDepAccountVM.AccountUpdate += Client_UpdateDB;
                client.Client.AccountUpdate += Client_UpdateDB;
            }

            SelectedClient = _clients.FirstOrDefault();
        }

        private void Client_CreateLog(object sender, LogInfoEventArgs e)
        {
            ClientViewModel client = sender as ClientViewModel;
            Logger logger = new Logger();
            LogInfo logInfo = new LogInfo()
            {
                Time = e.Time,
                AuthorName = e.AuthorName,
                ClientName = $"{client.FirstName} {client.SecondName} {client.MiddleName}",
                TransactionType = e.TransactionType,
                TransactionSum = e.TransactionSum
            };

            logger.WriteLog(logInfo);

            new ToastContentBuilder()
                .AddText($"{client.FirstName} {client.SecondName} {client.MiddleName}")
                .AddText(e.TransactionType)
                .Show();
        }

        private void Client_UpdateDB(object sender, LogInfoEventArgs e)
        {
            var clients = _clients.Select(x => x.GetClient());
            _repository.UpdateDatabase(clients);

            Clients = new ObservableCollection<ClientViewModel>(_repository
                                                        .GetClients()
                                                        .Select(x => new ClientViewModel(x, this)));

            foreach (var client in _clients)
            {
                client.AccountUpdate += Client_CreateLog;
                client.DepAccountVM.AccountUpdate += Client_CreateLog;
                client.NonDepAccountVM.AccountUpdate += Client_CreateLog;

                client.AccountUpdate += Client_UpdateDB;
                client.DepAccountVM.AccountUpdate += Client_UpdateDB;
                client.NonDepAccountVM.AccountUpdate += Client_UpdateDB;
                client.Client.AccountUpdate += Client_UpdateDB;
            }

            SelectedClient = _clients.FirstOrDefault();
        }

        public ObservableCollection<ClientViewModel> Clients
        {
            get => _clients;
            set => RaiseAndSetIfChanged(ref _clients, value);
        }

        public ClientViewModel SelectedClient
        {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }

        public List<ClientViewModel> ClientsWithDepAccounts => _clients             
                    .Where(x => x.DepAccountVM.BankAccount != null)
                    .ToList();
    }
}
