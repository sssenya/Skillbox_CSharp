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
    internal class ConsultantViewModel : EmployeeViewModel
    {
        public ConsultantViewModel(Repository repository)
        {
            _repository = repository;
            _clients = new ObservableCollection<IClientInfo>();

            foreach (Client client in repository.GetClients())
            {
                _clients.Add(new ClientByConsViewModel(client, this));
            }

            UpdateCommand = new RelayCommand(obj => UpdateClientsInfo(), obj => base.CanExecute());
        }
    }
}
