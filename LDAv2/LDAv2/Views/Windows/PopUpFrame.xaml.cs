using LDAv2.Views.Panels;
using System;
using System.Windows;
using System.Windows.Input;

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
