﻿using Practice_18_Patterns.ViewModels;
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

namespace Practice_18_Patterns.Views
{
    /// <summary>
    /// Interaction logic for NewAnimalWindow.xaml
    /// </summary>
    public partial class NewAnimalWindow : Window
    {
        public NewAnimalWindow(NewAnimalViewModel newAnimaVM)
        {
            DataContext = newAnimaVM;
            InitializeComponent();
        }
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
