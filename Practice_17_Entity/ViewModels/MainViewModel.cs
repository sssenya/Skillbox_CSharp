using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows.Input;

using Microsoft.EntityFrameworkCore;

namespace Practice_17_Entity
{
    public class MainViewModel : BaseViewModel
    {
        private readonly string _filePath;
        private readonly MsqltestContext _contextdb;

        private  Client _selectedClientRow;

        public MainViewModel()
        {
            _contextdb = new MsqltestContext();

            _contextdb.Clients.Load<Client>();
            Clients = _contextdb.Clients.Local.ToObservableCollection();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\Database";

            DeleteClientCommand = new RelayCommand(obj => DeleteSelectedClient());
            AddNewClientCommand = new RelayCommand(obj => OpenNewClientWindow());
            ShowPurchasesCommand = new RelayCommand(obj => ShowClientPurchases());
            CellChangedCommand = new RelayCommand(obj => CellChanged());
        }

        public ICommand DeleteClientCommand { get; set; }
        public ICommand AddNewClientCommand { get; set; }
        public ICommand ShowPurchasesCommand { get; set; }
        public ICommand CellChangedCommand { get; set; }

        public ObservableCollection<Client> Clients { get; set; }

        public DataView ClientsDataTable { get; set; }
        public Client SelectedClient {
            get => _selectedClientRow;
            set => RaiseAndSetIfChanged(ref _selectedClientRow, value);
        }

        public void DeleteSelectedClient() {
            _contextdb.Clients.Remove(_selectedClientRow);
            _contextdb.SaveChanges();
        }

        public void OpenNewClientWindow() {
            NewClientViewModel newClientVM = new NewClientViewModel(Clients);
            AddClientWindow window = new AddClientWindow(newClientVM);
            window.ShowDialog();
            _contextdb.SaveChanges();
        }

        public void ShowClientPurchases() {
            PurchasesViewModel purchasesVM = new PurchasesViewModel(_filePath, _selectedClientRow);
            PurchasesWindow window = new PurchasesWindow(purchasesVM);
            window.ShowDialog();
        }

        public void CellChanged() {
            if(_selectedClientRow == null) {
                return;
            }

            _contextdb.SaveChanges();
        }
    }
}
