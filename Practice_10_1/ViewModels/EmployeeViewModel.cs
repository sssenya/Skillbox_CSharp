﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Practice_10_1.Models;

namespace Practice_10_1.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel
    {
        protected ObservableCollection<Client> _clients;
        protected Client _selectedClient;
        protected IClientInfo _selectedClientInfo;
        protected Repository _repository;

        public EmployeeViewModel(Repository repository)
        {
            _repository = repository;            
            UpdateClientsFromDB();            
        }

        public string Name { get; set; }

        public IClientInfo SelectedClientInfo
        {
            get => _selectedClientInfo;
            set => RaiseAndSetIfChanged(ref _selectedClientInfo, value);
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => RaiseAndSetIfChanged(ref _clients, value);
        }

        public void UpdateClient(IClientInfo client)
        {          
            _clients.Remove(client.Client);
            _clients.Add(client.GetUpdatedClient());
            _repository.UpdateDatabase(_clients);
            UpdateClientsFromDB();
        }

        public void AddNewClient()
        {
            Client newClient = new Client
            {
                FirstName = "New",
                SecondName = "Client",
                MiddleName = "Name",
                PhoneNumber = "00000000000",
                PassportNumber = "0000000000"
            };

            _clients.Add(newClient);
            _repository.UpdateDatabase(_clients);
            UpdateClientsFromDB();
        }

        public void RemoveClient(IClientInfo client)
        {
            _clients.Remove(client.Client);
            _repository.UpdateDatabase(_clients);
            UpdateClientsFromDB();
        }

        public void UpdateClientsFromDB()
        {
            Clients = new ObservableCollection<Client>(_repository.GetClients());
        }
    }
}
