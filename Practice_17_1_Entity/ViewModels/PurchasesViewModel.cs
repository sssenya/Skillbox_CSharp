using System.Data;
using System.Data.OleDb;

using Practice_10_1.ViewModels;

namespace Practice_17_1_Entity {
    public class PurchasesViewModel : BaseViewModel {
        private DataRowView _selectedPurchase;

        private readonly string _filePath;

        private string _connectionStringMSAccess;

        private OleDbConnection _oledbConnection;
        private OleDbDataAdapter _oledbDataAdapter;
        private DataTable _oledbDataTable;

        public PurchasesViewModel(string filepath, DataRowView client)
        {
            _filePath = filepath;
            string clientEmail = client.Row["Email"].ToString();

            SetAccessConnection(clientEmail);
        }

        public void SetAccessConnection(string clientEmail) {
            OleDbConnectionStringBuilder connectionStringBuilderMSAccess = new OleDbConnectionStringBuilder() {
                DataSource = _filePath + @"\AccessLocalDB.mdb",
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };

            _connectionStringMSAccess = connectionStringBuilderMSAccess.ConnectionString;

            OleDbConnection _oledbConnection = new OleDbConnection() {
                ConnectionString = _connectionStringMSAccess
            };

            _oledbDataTable = new DataTable();
            _oledbDataAdapter = new OleDbDataAdapter();

            string sqlSelect = $@"SELECT * FROM Orders WHERE Email = ?";
            _oledbDataAdapter.SelectCommand = new OleDbCommand(sqlSelect, _oledbConnection);
            _oledbDataAdapter.SelectCommand.Parameters.AddWithValue("@p1", clientEmail);

            _oledbDataAdapter.Fill(_oledbDataTable);
            PurchasesDataTable = _oledbDataTable.DefaultView;
        }

        public DataRowView SelectedPurchase {
            get => _selectedPurchase;
            set => RaiseAndSetIfChanged(ref _selectedPurchase, value);
        }

        public DataView PurchasesDataTable { get; set; }
    }
}
