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
    internal class ManagerViewModel : EmployeeViewModel
    {
        public ManagerViewModel(Repository repository) : base(repository)
        {
        }

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
