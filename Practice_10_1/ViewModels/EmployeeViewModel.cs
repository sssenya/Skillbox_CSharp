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
        protected ObservableCollection<IClientInfo> _clients;
        protected IClientInfo _selectedClient;
        protected Repository _repository;

        protected ICommand UpdateCommand { get; set; }
        public string Name { get; set; }
        public IClientInfo SelectedClient
        {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }
        public ObservableCollection<IClientInfo> Clients => _clients;

        public void UpdateClientsInfo()
        {
            _repository.UpdateDatabase(_clients);
        }

        protected bool CanExecute()
        {
            foreach (var client in Clients)
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
