using Practice_10_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10_1.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ClientInfoViewModel> _clients;
        private ClientInfoViewModel _selectedClient;

        public MainViewModel()
        {
            _clients = new ObservableCollection<ClientInfoViewModel>();

            Repository repository = new Repository();
            foreach(Client client in repository.GetClients())
            {
                _clients.Add(new ClientInfoViewModel(client));
            }
        }

        public ClientInfoViewModel SelectedClient
        {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }

        public ObservableCollection<ClientInfoViewModel> Clients => _clients;
    }
}
