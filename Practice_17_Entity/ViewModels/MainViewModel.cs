using System;
using System.Data;
using System.IO;
using System.Windows.Input;

using Microsoft.Data.SqlClient;

namespace Practice_17_Entity
{
    public class MainViewModel : BaseViewModel
    {
        private readonly string _filePath;
        private string _connectionStringMSSQL;

        private Client _selectedClientRow;

        private SqlDataAdapter _sqlDataAdapter;
        private DataTable _sqlDataTable;


        public MainViewModel()
        {
            MsqltestContext context = new MsqltestContext();
            Clients = context.Clients.ToList();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\Database";

            SetMSSQLConnection();

            OpenInfoWindowCommand = new RelayCommand(obj => OpenConnectionInfoWindow());
            //DeleteClientCommand = new RelayCommand(obj => DeleteSelectedClient());
            AddNewClientCommand = new RelayCommand(obj => OpenNewClientWindow());
            //ShowPurchasesCommand = new RelayCommand(obj => ShowClientPurchases());
            //CellChangedCommand = new RelayCommand(obj => CellChanged());
            //EditCellEndingCommand = new RelayCommand(obj => EditCellEnding());
        }

        public ICommand OpenInfoWindowCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        public ICommand AddNewClientCommand { get; set; }
        public ICommand ShowPurchasesCommand { get; set; }
        public ICommand CellChangedCommand { get; set; }
        public ICommand EditCellEndingCommand { get; set; }

        public List<Client> Clients { get; set; }
        public string ConnectionStateMSSQL { get; set; }
        public string ConnectionStringMSSQL => _connectionStringMSSQL;

        public DataView ClientsDataTable { get; set; }
        public Client SelectedClient {
            get => _selectedClientRow;
            set => RaiseAndSetIfChanged(ref _selectedClientRow, value);
        }

        public void SetMSSQLConnection() {
            SqlConnectionStringBuilder connectionStringBuilderMSSQL = new SqlConnectionStringBuilder() {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSQLTest",
                IntegratedSecurity = true
            };

            _connectionStringMSSQL = connectionStringBuilderMSSQL.ConnectionString;

            SqlConnection connection = new SqlConnection(_connectionStringMSSQL);

            _sqlDataTable = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter();

            string sqlSelect = @"SELECT * FROM Clients Order By Clients.Id";
            _sqlDataAdapter.SelectCommand = new SqlCommand(sqlSelect, connection);

            string sqlInsert = @"INSERT INTO Clients (SecondName,  FirstName, MiddleName, PhoneNumber, Email) 
                               VALUES (@SecondName, @FirstName, @MiddleName, @PhoneNumber, @Email); 
                               SET @id = @@IDENTITY;";
            _sqlDataAdapter.InsertCommand = new SqlCommand(sqlInsert, connection);
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@SecondName", SqlDbType.NVarChar, 20, "SecondName");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 20, "MiddleName");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@PhoneNumber", SqlDbType.Int, 4, "PhoneNumber");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 20, "Email");

            string sqlUpdate = @"UPDATE Clients SET 
                               SecondName = @SecondName,
                               FirstName = @FirstName, 
                               MiddleName = @MiddleName, 
                               PhoneNumber = @PhoneNumber,
                               Email = @Email 
                               WHERE Id = @Id";
            _sqlDataAdapter.UpdateCommand = new SqlCommand(sqlUpdate, connection);
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@SecondName", SqlDbType.NVarChar, 20, "SecondName");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 20, "MiddleName");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@PhoneNumber", SqlDbType.Int, 4, "PhoneNumber");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 20, "Email");

            string sqlDelete = "DELETE FROM Clients WHERE Id = @Id";
            _sqlDataAdapter.DeleteCommand = new SqlCommand(sqlDelete, connection);
            _sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");


            _sqlDataAdapter.Fill(_sqlDataTable);
            ClientsDataTable = _sqlDataTable.DefaultView;

            connection.StateChange +=
                (s, e) => { ConnectionStateMSSQL = (s as SqlConnection).State.ToString(); };
        }

        public void OpenConnectionInfoWindow() {
            ConnectionInfoViewModel connectionInfoVM = new ConnectionInfoViewModel(this);
            ConnectionInfoWindow window = new ConnectionInfoWindow(connectionInfoVM);
            window.ShowDialog();
        }

        //public void DeleteSelectedClient() {
        //    SelectedClient.Row.Delete();
        //    _sqlDataAdapter.Update(_sqlDataTable);
        //}

        public void OpenNewClientWindow() {
            NewClientViewModel newClientVM = new NewClientViewModel(_sqlDataAdapter, _sqlDataTable);
            AddClientWindow window = new AddClientWindow(newClientVM);
            window.ShowDialog();
        }

        //public void ShowClientPurchases() {
        //    PurchasesViewModel purchasesVM = new PurchasesViewModel(_filePath, _selectedClientRow);
        //    PurchasesWindow window = new PurchasesWindow(purchasesVM);
        //    window.ShowDialog();
        //}

        //public void CellChanged() {
        //    if(_selectedClientRow == null) {
        //        return;
        //    }
        //    _selectedClientRow.EndEdit();
        //    _sqlDataAdapter.Update(_sqlDataTable);
        //}

        //public void EditCellEnding() {
        //    _selectedClientRow.BeginEdit();
        //}
    }
}
