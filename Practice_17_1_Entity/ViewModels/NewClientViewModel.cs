using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;

using Practice_10_1.Commands;
using Practice_10_1.ViewModels;

namespace Practice_17_1_Entity {
    public class NewClientViewModel : BaseViewModel {

        private readonly SqlDataAdapter _sqlDataAdapter;
        private readonly DataTable _dataTable;

        private string _secondName;
        private string _firstName;
        private string _middleName;
        private string _phoneNumber;
        private string _email;

        public NewClientViewModel(SqlDataAdapter sqlDataAdapter, DataTable dataTable) {
            _sqlDataAdapter = sqlDataAdapter;
            _dataTable = dataTable;

            AddNewClientCommand = new RelayCommand(obj => AddNewClient());            
        }

        public ICommand AddNewClientCommand { get; set; }

        public string SecondName {
            get => _secondName;
            set => RaiseAndSetIfChanged(ref _secondName, value);
        }

        public string FirstName {
            get => _firstName;
            set => RaiseAndSetIfChanged(ref _firstName, value);
        }

        public string MiddleName {
            get => _middleName;
            set => RaiseAndSetIfChanged(ref _middleName, value);
        }

        public string PhoneNumber {
            get => _phoneNumber;
            set => RaiseAndSetIfChanged(ref _phoneNumber, value);
        }

        public string Email {
            get => _email;
            set => RaiseAndSetIfChanged(ref _email, value);
        }

        public void AddNewClient() {
            DataRow newRow = _dataTable.NewRow();

            newRow["SecondName"] = SecondName;
            newRow["FirstName"] = FirstName;
            newRow["MiddleName"] = MiddleName;
            newRow["PhoneNumber"] = int.Parse(PhoneNumber);
            newRow["Email"] = Email;

            _dataTable.Rows.Add(newRow);
            _sqlDataAdapter.Update(_dataTable);
        }
    }
}

