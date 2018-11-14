using LDAv2.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace LDAv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginPanel login;
        public MainWindow()
        {
            InitializeComponent();
            sgrid.Children.Add(login = new LoginPanel(sgrid));
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
