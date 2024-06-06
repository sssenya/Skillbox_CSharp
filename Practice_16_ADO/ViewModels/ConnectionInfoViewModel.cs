namespace Practice_16_ADO.ViewModels {
    public class ConnectionInfoViewModel {
        public ConnectionInfoViewModel(MainViewModel mainViewModel) {
            ConnectionStringMSSQL = mainViewModel.ConnectionStringMSSQL;
            ConnectionStateMSSQL = mainViewModel.ConnectionStateMSSQL;
        }

        public string ConnectionStateMSSQL { get; set; }
        public string ConnectionStringMSSQL { get; set; }
    }
}
