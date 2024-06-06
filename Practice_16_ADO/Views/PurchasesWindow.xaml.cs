using System.Windows;

using Practice_16_ADO.ViewModels;

namespace Practice_16_ADO.Views {
    public partial class PurchasesWindow : Window {
        public PurchasesWindow(PurchasesViewModel purchasesViewModel) {
            InitializeComponent();
            DataContext = purchasesViewModel;
        }
    }
}
