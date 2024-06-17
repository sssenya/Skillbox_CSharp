using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Practice_17_Entity {
    public class NewClientViewModel : BaseViewModel {

        private readonly ObservableCollection<Client> _clients;

        private string _secondName;
        private string _firstName;
        private string _middleName;
        private string _phoneNumber;
        private string _email;

        public NewClientViewModel(ObservableCollection<Client> сlients) {
            _clients = сlients;

            AddNewClientCommand = new RelayCommand(obj => AddNewClient());            
        }

        public ICommand AddNewClientCommand { get; set; }

        public string SecondName {
            get => _secondName;
            set => RaiseAndSetIfChanged(ref _secondName, value);
        }

        public string FirstName {
            get => _firstName;
            set => RaiseAndSetIfChanged(ref _firstName, value);
        }

        public string MiddleName {
            get => _middleName;
            set => RaiseAndSetIfChanged(ref _middleName, value);
        }

        public string PhoneNumber {
            get => _phoneNumber;
            set => RaiseAndSetIfChanged(ref _phoneNumber, value);
        }

        public string Email {
            get => _email;
            set => RaiseAndSetIfChanged(ref _email, value);
        }

        public void AddNewClient() {
            Client newClient = new Client();

            newClient.SecondName = SecondName;
            newClient.FirstName = FirstName;
            newClient.MiddleName = MiddleName;
            if(int.TryParse(PhoneNumber, out int result)) {
                newClient.PhoneNumber = result;
            }
            newClient.Email = Email;

            _clients.Add(newClient);
        }
    }
}

