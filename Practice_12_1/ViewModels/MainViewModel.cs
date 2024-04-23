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

        public MainViewModel()
        {
            Repository repository = new Repository();

            _clients = new ObservableCollection<ClientViewModel>(repository
                                                                    .GetClients()
                                                                    .Select(x => new ClientViewModel(x, this)));

            foreach(var client in _clients)
            {
                client.CreateLog += Client_CreateLog;
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
