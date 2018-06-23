using LDAv2.Controller;
using LDAv2.Model;
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
            if (username.Text != "" && username.Text.Length >= 5 && fullname.Text != "" && email.Text != "" && email.Text.Length >= 5 && pass_1.Password != "" && pass_2.Password != "" && !l_control.Registration_Username_Checker(username.Text) &&!l_control.Registration_Email_Checker(email.Text) && pass_1.Password == pass_2.Password && pass_1.Password.Length >= 5 && pass_2.Password.Length >= 5)
            {
                List<Registration_struct> list = new List<Registration_struct>();
                list.Add(new Registration_struct
                {
                    username = username.Text,
                    pass = pass_1.Password,
                    real_name = fullname.Text,
                    auth = 1,
                    email = email.Text,
                    valid = 1,
                    admintag = 0,
                    lastlogindate = "",
                    language = 1
                });
                l_control.User_Registration_Write(list);

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

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!l_control.Registration_Username_Checker(username.Text) && username.Text != "" && username.Text.Length >= 5)
            {
                user_check.Visibility = Visibility.Visible;
            }
            else
            {
                user_check.Visibility = Visibility.Hidden;
            }
        }
        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!l_control.Registration_Email_Checker(email.Text) && email.Text != "" && email.Text.Length >= 5)
            {
                email_check.Visibility = Visibility.Visible;
            }
            else
            {
                email_check.Visibility = Visibility.Hidden;
            }
        }

        private void pass_1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(pass_1.Password.Length >= 5)
            {
                pass1_check.Visibility = Visibility.Visible;
            }
            else
            {
                pass1_check.Visibility = Visibility.Hidden;
            }
        }
        private void pass_2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pass_1.Password == pass_2.Password &&  pass_2.Password.Length >= 5)
            {
                pass2_check.Visibility = Visibility.Visible;
            }
            else
            {
                pass2_check.Visibility = Visibility.Hidden;
            }
        }
    }
}
