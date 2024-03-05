﻿using Newtonsoft.Json.Linq;
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

        public ObservableCollection<IClientInfo> Clients {
            get => _clients;
            set => RaiseAndSetIfChanged(ref _clients, value);
        }

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

        public void UpdateClient(IClientInfo client)
        {
            List<Client> clients = _repository.GetClients();
            clients.Remove(client.Client);
            clients.Add(client.GetUpdatedClient());
            _repository.UpdateDatabase(_clients);
            _clients = new ObservableCollection<IClientInfo>();
            foreach (Client client2 in clients)
            {
                _clients.Add(new ClientByConsViewModel(client2, this));
            }
        }
    }
}
