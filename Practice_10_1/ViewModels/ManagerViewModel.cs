using System;

using Practice_10_1.Models;

namespace Practice_10_1.ViewModels
{
    internal class ManagerViewModel : EmployeeViewModel
    {
        public ManagerViewModel(Repository repository) : base(repository) { }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                RaiseAndSetIfChanged(ref _selectedClient, value);
                if (_selectedClient != null)
                {
                    SelectedClientInfo = new ClientByManagerViewModel(_selectedClient, this);
                    OnPropertyChanged("SelectedClientInfo");
                }
            }
        }
    }
}
