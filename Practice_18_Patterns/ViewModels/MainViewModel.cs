using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.WindowsAPICodePack.Dialogs;
using Practice_17_Entity;
using Practice_18_Patterns.Models;
using Practice_18_Patterns.Views;

namespace Practice_18_Patterns.ViewModels {
    internal class MainViewModel : BaseViewModel {

        private IAnimal _selectedAnimal;
        public MainViewModel()
        {
            Animals = new ObservableCollection<IAnimal>()
            {
                AnimalFactory.GetAnimal("Птицы", "Совообразные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Птицы", "Голубеобразные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Птицы", "Журавлеобразные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Птицы", "Ястребообразные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Земноводные", "Аделоспондилы", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Земноводные", "Безногие земноводные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Земноводные", "Хвостатые земноводные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Млекопитающие", "Насекомоядные", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Млекопитающие", "Ценолесты", "Семейство", "Вид"),
                AnimalFactory.GetAnimal("Млекопитающие", "Прыгунчики", "Семейство", "Вид")
            };

            OpenNewAnimalWindowCommand = new RelayCommand(obj => OpenNewAnimalWindow());
            ExportToJsonCommand = new RelayCommand(obj => ExportToJson());
            ExportToTxtCommand = new RelayCommand(obj => ExportToTxt());
        }

        public ICommand OpenNewAnimalWindowCommand { get; set; }
        public ICommand ExportToJsonCommand { get; set; }
        public ICommand ExportToTxtCommand { get; set; }
        public ObservableCollection<IAnimal> Animals { get; set; }
        public IAnimal SelectedAnimal {
            get => _selectedAnimal;
            set => RaiseAndSetIfChanged(ref _selectedAnimal, value);
        }

        public void OpenNewAnimalWindow()
        {
            NewAnimalViewModel newAnimaVM = new NewAnimalViewModel(Animals);

            NewAnimalWindow window = new NewAnimalWindow(newAnimaVM);
            window.ShowDialog();
        }

        public void ExportToJson()
        {
            string filePath;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                filePath = dialog.FileName;
                AnimalSaver saver = new AnimalSaver(new KeeperJson(filePath));
                saver.Animals = Animals.ToList();
                saver.Save();
            }
        }

        public void ExportToTxt()
        {
            string filePath;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                filePath = dialog.FileName;
                AnimalSaver saver = new AnimalSaver(new KeeperTxt(filePath));
                saver.Animals = Animals.ToList();
                saver.Save();
            }
        }
    }
}
