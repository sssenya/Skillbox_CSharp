using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Practice_17_Entity;
using Practice_18_Patterns.Models;

namespace Practice_18_Patterns.ViewModels {
    internal class MainViewModel : BaseViewModel {

        private IAnimal _selectedAnimal;
        public MainViewModel()
        {
            Animals = new ObservableCollection<IAnimal>()
            {
                AnimalFactory.GetAnimal("Птицы", "Совообразные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Птицы", "Голубеобразные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Птицы", "Журавлеобразные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Птицы", "Ястребообразные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Земноводные", "Аделоспондилы", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Земноводные", "Безногие земноводные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Земноводные", "Хвостатые земноводные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Млекопитающие", "Насекомоядные", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Млекопитающие", "Ценолесты", "Семейство", "Род"),
                AnimalFactory.GetAnimal("Млекопитающие", "Прыгунчики", "Семейство", "Род")
            };

            AddNewAnimalCommand = new RelayCommand(obj => AddNewAnimal());
        }

        public ICommand AddNewAnimalCommand { get; set; }
        public ObservableCollection<IAnimal> Animals { get; set; }
        public IAnimal SelectedAnimal {
            get => _selectedAnimal;
            set => RaiseAndSetIfChanged(ref _selectedAnimal, value);
        }

        public void AddNewAnimal()
        {
            Animals.Add(AnimalFactory.GetAnimal("Птицы", "Отряд", "Семейство", "Род"));
        }
    }
}
