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
        private ObservableCollection<EmployeeViewModel> _employees;
        private EmployeeViewModel _selectedEmployee;

        public MainViewModel()
        {
            Repository repository = new Repository();

            _employees = new ObservableCollection<EmployeeViewModel>()
            {
                new ConsultantViewModel(repository) { Name = "Консультант"},
                new ManagerViewModel(repository) { Name = "Менеджер"}
            };

            SelectedEmployee = _employees[0];
        }

        public EmployeeViewModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                RaiseAndSetIfChanged(ref _selectedEmployee, value);
                _selectedEmployee.UpdateClientsFromDB();
            }
        }

        public ObservableCollection<EmployeeViewModel> Employees => _employees;
    }
}
