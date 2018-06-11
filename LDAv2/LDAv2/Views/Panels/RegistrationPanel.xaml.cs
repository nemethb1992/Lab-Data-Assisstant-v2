using LDAv2.Controller;
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

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for RegistrationPanel.xaml
    /// </summary>
    public partial class RegistrationPanel : UserControl
    {
        private Grid grid;
        login_control l_control = new login_control();
        Session session = new Session();
        public RegistrationPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
        }


        private void Back_Click_btn(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            var window = Window.GetWindow(this);
            window.Close();
            login.Show();
        }
        private void Registration_Click_btn(object sender, RoutedEventArgs e)
        {
            if (teljesnev.Text != "" && email.Text != "")
            {
                // TODO megírni a regisztrációt
                MainWindow login = new MainWindow();
                var window = Window.GetWindow(this);
                window.Close();
                login.Show();
            }
            else
            {
                InfoBlock.Text = "Kitöltetlen mező!";
            }
        }
    }
}
