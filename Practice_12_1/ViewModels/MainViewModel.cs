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
        private ObservableCollection<Client> _clients;

        public MainViewModel()
        {
            Repository repository = new Repository();

            _clients = new ObservableCollection<Client>(repository.GetClients());
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => RaiseAndSetIfChanged(ref _clients, value);
        }
    }
}
