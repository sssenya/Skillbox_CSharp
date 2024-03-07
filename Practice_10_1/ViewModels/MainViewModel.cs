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
        private ObservableCollection<IBankEmployee> _employees;
        private IBankEmployee _selectedEmployee;

        public MainViewModel()
        {
            Repository repository = new Repository();

            _employees = new ObservableCollection<IBankEmployee>()
            {
                new ConsultantViewModel(repository) { Name = "Консультант"},
                new ManagerViewModel(repository) { Name = "Менеджер"}
            };

            SelectedEmployee = _employees[0];
        }

        public IBankEmployee SelectedEmployee
        {
            get => _selectedEmployee;
            set => RaiseAndSetIfChanged(ref _selectedEmployee, value);
        }

        public ObservableCollection<IBankEmployee> Employees => _employees;
    }
}
