using Practice_10_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal class ManagerViewModel : BaseViewModel, IBankEmployee
    {
        private ObservableCollection<IClientInfo> _clients;
        private IClientInfo _selectedClient;
        private Repository _repository;

        public ManagerViewModel(Repository repository)
        {
            _repository = repository;
            _clients = new ObservableCollection<IClientInfo>();

            foreach (Client client in repository.GetClients())
            {
                _clients.Add(new ClientByManagerViewModel(client));
            }
        }

        public string Name { get; set; }

        public IClientInfo SelectedClient
        {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }

        public ObservableCollection<IClientInfo> Clients => _clients;

        public ClientByConsViewModel GetClientInfo(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
