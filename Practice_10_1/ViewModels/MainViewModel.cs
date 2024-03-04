using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Practice_10_1.Commands;
using Practice_10_1.Models;

namespace Practice_10_1.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<IClientInfo> _clients;
        private ObservableCollection<IBankEmployee> _employees;
        private Repository _repository;
        private IBankEmployee _selectedEmployee;

        public MainViewModel()
        {
            _repository = new Repository();

            _employees = new ObservableCollection<IBankEmployee>()
            {
                new ConsultantViewModel(_repository) { Name = "Консультант"},
                new ManagerViewModel(_repository) { Name = "Менеджер"}
            };

            UpdateCommand = new RelayCommand(obj => UpdateClientsInfo(), obj => CanExecute());
        }

        public ICommand UpdateCommand { get; }

        public IBankEmployee SelectedEmployee
        {
            get => _selectedEmployee;
            set => RaiseAndSetIfChanged(ref _selectedEmployee, value);
        }

        public ObservableCollection<IBankEmployee> Employees => _employees;

        public void UpdateClientsInfo()
        {
            _repository.UpdateDatabase(_clients);
        }

        private bool CanExecute()
        {
            //foreach(var client in Clients)
            //{
            //    if (string.IsNullOrEmpty(client.PhoneNumber))
            //    {
            //        return false;
            //    }
            //}

            return true;
        } 
    }
}
