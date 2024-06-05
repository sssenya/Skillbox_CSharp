using Practice_16_ADO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practice_16_ADO.Views {
    public partial class AddClientWindow : Window {
        public AddClientWindow(NewClientViewModel newClientViewModel) {
            InitializeComponent();
            DataContext = newClientViewModel;
        }
    }
}
