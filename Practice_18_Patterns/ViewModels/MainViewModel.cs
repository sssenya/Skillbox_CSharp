using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Practice_17_Entity;
using Practice_18_Patterns.Models;

namespace Practice_18_Patterns.ViewModels {
    internal class MainViewModel : BaseViewModel {

        private IAnimal _selectedAnimal;
        public MainViewModel()
        {
            Animals = new ObservableCollection<IAnimal>();
            Animals.Add(new Bird());
        }

        public ObservableCollection<IAnimal> Animals { get; set; }
        public IAnimal SelectedAnimal {
            get => _selectedAnimal;
            set => RaiseAndSetIfChanged(ref _selectedAnimal, value);
        }
    }
}
