using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_16_ADO.ViewModels
{
    internal class MainViewModel
    {
        
        
        public MainViewModel()
        {
            SetConnection();
        }

        public void SetConnection()
        {
            SqlConnectionStringBuilder connectionStr = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLTest",
                IntegratedSecurity = true
            };

            SqlConnection connection = new SqlConnection()
            {
                ConnectionString = connectionStr.ConnectionString
            };

            connection.StateChange +=
                (s, e) => { ConnectionStateMSSQL = (s as SqlConnection).State.ToString(); };

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
        }

        public string ConnectionStateMSSQL { get; set; }
    }
}
