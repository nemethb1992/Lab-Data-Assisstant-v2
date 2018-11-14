using LDAv2.Controller;
using LDAv2.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for RegistrationPanel.xaml
    /// </summary>
    public partial class RegistrationPanel : UserControl
    {
        private Grid grid;
        Login login = new Login();

        public RegistrationPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            LangControl_Registration();
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
            if (username.Text.Length >= 5 && fullname.Text.Length >= 5 && email.Text.Length >= 5 && pass_1.Password == pass_2.Password && pass_1.Password.Length >= 5 && pass_2.Password.Length >= 5 && !login.IsExistsByUsername(username.Text) &&!login.IsExistsByEmail(email.Text))
            {
                List<UserData> list = new List<UserData>();
                list.Add(new UserData
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
                this.login.Insert(list);

                MainWindow login = new MainWindow();
                var window = Window.GetWindow(this);
                window.Close();
                login.Show();
            }
            else
            {
                InfoBlock.Text = "Hibás kitöltés!";
            }
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!login.IsExistsByUsername(username.Text) && username.Text.Length >= 5)
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
            if (!login.IsExistsByEmail(email.Text) && email.Text.Length >= 5)
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

        private void fullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fullname.Text.Length >= 5)
            {
                fullname_check.Visibility = Visibility.Visible;
            }
            else
            {
                fullname_check.Visibility = Visibility.Hidden;
            }
        }
        private void LangControl_Registration()
        {
            Dictionary dict = new Dictionary();

            Reg_label.Text = dict.Word(10);
            felhasznalonev_label.Text = dict.Word(7);
            teljesnev_label.Text = dict.Word(11);
            email_label.Text = dict.Word(13);
            jelszo_label.Text = dict.Word(8);
            jelszoismet_label.Text = dict.Word(12);
            Back_btn.Content = dict.Word(14);
            Registration_btn.Content = dict.Word(10);
        }
    }
}
