﻿using LDAv2.Views.Panels;
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

namespace LDAv2.Views.Windows
{
    /// <summary>
    /// Interaction logic for PopUpFrame.xaml
    /// </summary>
    public partial class PopUpFrame : Window
    {
        private RegistrationPanel registrationPanel;
        public PopUpFrame()
        {
            InitializeComponent();
            SwitchGrid.Children.Add(registrationPanel = new RegistrationPanel(SwitchGrid));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
