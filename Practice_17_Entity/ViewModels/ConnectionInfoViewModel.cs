namespace Practice_17_Entity {
    public class ConnectionInfoViewModel {
        public ConnectionInfoViewModel(MainViewModel mainViewModel) {
            ConnectionStringMSSQL = mainViewModel.ConnectionStringMSSQL;
            ConnectionStateMSSQL = mainViewModel.ConnectionStateMSSQL;
        }

        public string ConnectionStateMSSQL { get; set; }
        public string ConnectionStringMSSQL { get; set; }
    }
}
