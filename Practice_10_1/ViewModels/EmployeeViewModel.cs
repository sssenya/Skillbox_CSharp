using Newtonsoft.Json.Linq;
using Practice_10_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice_10_1.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel, IBankEmployee
    {
        protected ObservableCollection<Client> _clients;
        protected Client _selectedClient;
        protected IClientInfo _selectedClientInfo;
        protected Repository _repository;

        public EmployeeViewModel(Repository repository)
        {
            _repository = repository;
            _clients = new ObservableCollection<Client>();

            foreach (Client client in repository.GetClients())
            {
                _clients.Add(client);
            }
        }

        protected ICommand UpdateCommand { get; set; }

        public string Name { get; set; }

        public IClientInfo SelectedClientInfo
        {
            get => _selectedClientInfo;
            set => RaiseAndSetIfChanged(ref _selectedClientInfo, value);
        }

        public ObservableCollection<Client> Clients {
            get => _clients;
            set => RaiseAndSetIfChanged(ref _clients, value);
        }

        public void UpdateClient(IClientInfo client)
        {          
            _clients.Remove(client.Client);
            _clients.Add(client.GetUpdatedClient());
            _repository.UpdateDatabase(_clients);

            ObservableCollection<Client> _clients2 = new ObservableCollection<Client>();
            foreach (Client client2 in _repository.GetClients())
            {
                _clients2.Add(client2);
            }

            Clients = _clients2;
        }
    }
}
