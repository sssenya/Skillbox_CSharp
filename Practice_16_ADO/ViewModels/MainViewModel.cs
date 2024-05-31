using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_16_ADO.ViewModels
{
    internal class MainViewModel
    {
        public MainViewModel()
        {
            SetMSSQLConnection();
            SetAccessConnection();
        }

        public void SetMSSQLConnection()
        {
            SqlConnectionStringBuilder connectionStr = new SqlConnectionStringBuilder() {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLTest",
                IntegratedSecurity = true
            };

            SqlConnection connection = new SqlConnection() {
                ConnectionString = connectionStr.ConnectionString,
            };

            connection.StateChange +=
                (s, e) => { ConnectionStateMSSQL = (s as SqlConnection).State.ToString(); };

            try {
                connection.Open();
            }
            catch (Exception e) {
                ConnectionStateMSSQL = e.Message;
            }
            finally {
                connection.Close();
            }
        }

        public void SetAccessConnection() {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\AccessLocalDB\AccessLocalDB.mdb"); 

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
    }
}
