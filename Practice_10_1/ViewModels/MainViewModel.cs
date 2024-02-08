using Practice_10_1.Commands;
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
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ClientInfoViewModel> _clients;
        private ClientInfoViewModel _selectedClient;
        private Repository _repository;

        public MainViewModel()
        {
            _clients = new ObservableCollection<ClientInfoViewModel>();
            _repository = new Repository();

            foreach(Client client in _repository.GetClients())
            {
                _clients.Add(new ClientInfoViewModel(client));
            }

            UpdateCommand = new RelayCommand(obj => UpdateClientsInfo(), obj => CanExecute());
        }

        public ICommand UpdateCommand { get; }

        public ClientInfoViewModel SelectedClient
        {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }

        public ObservableCollection<ClientInfoViewModel> Clients => _clients;

        public void UpdateClientsInfo()
        {
            _repository.UpdateDatabase(_clients);
        }

        private bool CanExecute()
        {
            foreach(var client in Clients)
            {
                if (string.IsNullOrEmpty(client.PhoneNumber))
                {
                    return false;
                }
            }

            return true;
        } 
    }
}
