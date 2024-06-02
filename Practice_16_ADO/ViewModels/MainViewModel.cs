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

namespace Practice_16_ADO.ViewModels
{
    //Первый источник данных должен содержать таблицу с полями:
    //ID
    //Фамилия
    //Имя
    //Отчество
    //Номер телефона(может быть пустым)
    //Email.
    
    //Второй источник данных содержит таблицу со следующими полями:
    //ID
    //Email
    //Код товара
    //Наименование товара
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
                InitialCatalog = "MSSQLTest",
                IntegratedSecurity = true
            };

            _connectionStringMSSQL = connectionStringBuilderMSSQL.ConnectionString;

            SqlConnection connection = new SqlConnection() {
                ConnectionString = _connectionStringMSSQL
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
    }
}
