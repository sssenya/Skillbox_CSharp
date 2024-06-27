using System.Windows;

using Practice_18_Patterns.ViewModels;

namespace Practice_18_Patterns {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}