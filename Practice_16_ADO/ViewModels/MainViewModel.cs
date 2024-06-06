using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

using Practice_10_1.ViewModels;
using Practice_10_1.Commands;
using Practice_16_ADO.Views;

namespace Practice_16_ADO.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly string _filePath;

        private string _connectionStringMSSQL;
        private string _connectionStringMSAccess;

        private DataRowView _selectedClient;

        private SqlConnection _connection;
        private SqlDataAdapter _sqlDataAdapter;
        private DataTable _dataTable;

        public MainViewModel()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\Database";

            SetMSSQLConnection();
            SetAccessConnection();

            OpenInfoWindow = new RelayCommand(obj => OpenConnectionInfoWindow());
            DeleteClient = new RelayCommand(obj => DeleteSelectedClient());
            AddNewClient = new RelayCommand(obj => OpenNewClientWindow());
            ShowPurchases = new RelayCommand(obj => ShowClientPurchases());
        }

        public ICommand OpenInfoWindow { get; set; }
        public ICommand DeleteClient { get; set; }
        public ICommand AddNewClient { get; set; }
        public ICommand ShowPurchases { get; set; }

        public void SetMSSQLConnection()
        {
            SqlConnectionStringBuilder connectionStringBuilderMSSQL = new SqlConnectionStringBuilder() {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSQLTest",
                IntegratedSecurity = true
            };

            _connectionStringMSSQL = connectionStringBuilderMSSQL.ConnectionString;

            SqlConnection connection = new SqlConnection(_connectionStringMSSQL);

            _dataTable = new DataTable();
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
                           PhoneNumber = @PhoneNumber 
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


            _sqlDataAdapter.Fill(_dataTable);
            ClientsDataTable = _dataTable.DefaultView;

            connection.StateChange +=
                (s, e) => { ConnectionStateMSSQL = (s as SqlConnection).State.ToString(); };
        }

        public void SetAccessConnection() {
            OleDbConnectionStringBuilder connectionStringBuilderMSAccess = new OleDbConnectionStringBuilder() {
                DataSource = _filePath + @"\AccessLocalDB.mdb",
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };

            _connectionStringMSAccess = connectionStringBuilderMSAccess.ConnectionString;

            OleDbConnection connection = new OleDbConnection() {
                ConnectionString = _connectionStringMSAccess
            }; 

            connection.StateChange +=
                (s, e) => { ConnectionStateMSAccess = (s as OleDbConnection).State.ToString(); };

            try {
                connection.Open();
            }
            catch(Exception e) {
                ConnectionStateMSAccess = e.Message;
            }
            finally {
                connection.Close();
            }
        }

        public string ConnectionStateMSSQL { get; set; }
        public string ConnectionStateMSAccess { get; set; }

        public string ConnectionStringMSSQL => _connectionStringMSSQL;
        public string ConnectionStringMSAccess => _connectionStringMSAccess;

        public DataRowView SelectedClient {
            get => _selectedClient;
            set => RaiseAndSetIfChanged(ref _selectedClient, value);
        }

        public DataView ClientsDataTable { get; set; }

        public void OpenConnectionInfoWindow() {
            ConnectionInfoViewModel connectionInfoVM = new ConnectionInfoViewModel(this);
            ConnectionInfoWindow window = new ConnectionInfoWindow(connectionInfoVM);
            window.ShowDialog();
        }

        public void DeleteSelectedClient() {
            SelectedClient.Row.Delete();
            _sqlDataAdapter.Update(_dataTable);
        }

        public void OpenNewClientWindow() {            
            NewClientViewModel newClientVM = new NewClientViewModel(_sqlDataAdapter, _dataTable);
            AddClientWindow window = new AddClientWindow(newClientVM);
            window.ShowDialog();
        }

        public void ShowClientPurchases() {
            PurchasesViewModel purchasesVM = new PurchasesViewModel();
            PurchasesWindow window = new PurchasesWindow(purchasesVM);
            window.ShowDialog();
        }
    }
}
