using System.Windows;

using Practice_18_Patterns.ViewModels;

namespace Practice_18_Patterns.Views
{
    public partial class NewAnimalWindow : Window
    {
        public NewAnimalWindow(NewAnimalViewModel newAnimaVM) {
            DataContext = newAnimaVM;
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
            DialogResult = false;
        }
    }
}
