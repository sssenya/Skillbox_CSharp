﻿using Practice_12_1.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice_12_1.Views
{
    public partial class ClientInfoWindow : Window
    {
        internal ClientInfoWindow(ClientInfoViewModel clientInfoViewModel)
        {
            InitializeComponent();

            DataContext = clientInfoViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
