using System.Collections.ObjectModel;
using System.Windows.Input;

using Practice_17_Entity;
using Practice_18_Patterns.Models;

namespace Practice_18_Patterns.ViewModels {
    public class NewAnimalViewModel : BaseViewModel {
        private ObservableCollection<IAnimal> _animals;
        private string _class;
        private string _order;
        private string _family;
        private string _species;

        public NewAnimalViewModel(ObservableCollection<IAnimal> animals) {
            _animals = animals;
            AddNewAnimalCommand = new RelayCommand(obj => AddNewAnimal());
        }

        public ICommand AddNewAnimalCommand { get; set; }

        public string Class {
            get => _class;
            set => RaiseAndSetIfChanged(ref _class, value);
        }

        public string Order {
            get => _order;
            set => RaiseAndSetIfChanged(ref _order, value);
        }

        public string Family {
            get => _family;
            set => RaiseAndSetIfChanged(ref _family, value);
        }

        public string Species {
            get => _species;
            set => RaiseAndSetIfChanged(ref _species, value);
        }

        public void AddNewAnimal() {
            _animals.Add(AnimalFactory.GetAnimal(_class, _order, _family, _species));
        }
    }
}
