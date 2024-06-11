using System.Windows;

namespace Practice_17_1_Entity {
    public partial class PurchasesWindow : Window {
        public PurchasesWindow(PurchasesViewModel purchasesViewModel) {
            InitializeComponent();
            DataContext = purchasesViewModel;
        }
    }
}
