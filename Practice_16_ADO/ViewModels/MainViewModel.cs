using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Practice_10_1.ViewModels;
using Practice_10_1.Commands;
using System.Data;

namespace Practice_16_ADO.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly string _filePath;

        private string _connectionStringMSSQL;
        private string _connectionStringMSAccess;

        public MainViewModel()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\Database";

            SetMSSQLConnection();
            SetAccessConnection();
        }

        public void SetMSSQLConnection()
        {
            SqlConnectionStringBuilder connectionStringBuilderMSSQL = new SqlConnectionStringBuilder() {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSQLTest",
                IntegratedSecurity = true
            };

            _connectionStringMSSQL = connectionStringBuilderMSSQL.ConnectionString;

            SqlConnection connection = new SqlConnection(_connectionStringMSSQL);

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            string sql = @"SELECT * FROM Clients Order By Clients.Id";
            dataAdapter.SelectCommand = new SqlCommand(sql, connection);

            dataAdapter.Fill(dataTable);

            ClientsDataTable = dataTable.DefaultView;


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

        public DataView ClientsDataTable { get; set; }
    }
}
