using LDAv2.Controller;
using LDAv2.Model;
using LDAv2.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LDAv2.Views
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class LoginPanel : UserControl
    {
        private Grid grid;
        Dictionary dict = new Dictionary();

        public LoginPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            //BootMethods();
            dbConnectionOpener();
            LangControl_Login();
            //MessageBox.Show(L.Word(10));
        }

        private void dbConnectionOpener()
        {
            if (!(new Database()).dbOpen())
            {
                LoginSign.Text = "Nincs adatkapcsolat!";
            }
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            enterApplication();
        }

        private void EnterKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            enterApplication();
        }
        
        //private void BootMethods()
        //{
        //    string user = login.GetRememberedUser();
        //    if (user != "")
        //    {
        //        Luser_tbx.Text = user;
        //        login_cbx.IsChecked = true;
        //    }
        //    else
        //    {
        //        login_cbx.IsChecked = false;
        //    }
        //}
        //private void UserRemember()
        //{
        //    if (login_cbx.IsChecked == true)
        //    {
        //        login.WriteRememberedUser(Luser_tbx.Text);
        //    }
        //    else
        //    {
        //        login.DeleteRememberedUser();
        //    }
        //}
        private void enterApplication()
        {


            //if (lcontrol.userValidation(Luser_tbx.Text, Lpass_pwd.Password))
            //{
            if (new Login().Validation(Luser_tbx.Text, Lpass_pwd.Password))
            {
                //UserRemember();
                Session.UserData = UserData.GetActual(Luser_tbx.Text, Lpass_pwd.Password);
                WorkWindow mw = new WorkWindow();
                mw.Show();
                var window = Window.GetWindow(this);
                window.Close();
            }

            else
            {
                LoginSign.Text = "Sikertelen bejelentkezés!";
                //Survey_Window SurvWindow = new Survey_Window();
                //var window = Window.GetWindow(this);
                //window.Close();
                //SurvWindow.Show();
            }

            //else
            //{
            //    MessageBox.Show("Tartományi hitelesítés sikertelen!");
            //}
            //if (lcontrol.userValidation(Luser_tbx.Text, Lpass_pwd.Password))

        }

        private void Registration_Click(object sender, MouseButtonEventArgs e)
        {
            PopUpFrame popup = new PopUpFrame();
            popup.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }
        private void LangControl_Login()
        {
            LoginSign.Text = dict.Word(104);
            login_cbx.Content = dict.Word(105);
            reg_btn.Text = dict.Word(10);
            btn_login.Content = dict.Word(9);
        }

        void Lang_nav_control()
        {
            if (lang_hu.IsVisible == false)
            {
                lang_hu.Visibility = Visibility.Visible;
                lang_de.Visibility = Visibility.Visible;
                lang_en.Visibility = Visibility.Visible;
            }
            else
            {
                lang_hu.Visibility = Visibility.Hidden;
                lang_de.Visibility = Visibility.Hidden;
                lang_en.Visibility = Visibility.Hidden;
            }
        }

        private void Lang_btn_Click(object sender, RoutedEventArgs e)
        {
            Lang_nav_control();
        }

        private void Lang_Selection(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag)
            {
                case "1":
                    {
                        dict.LanguageID = 1;
                        break;
                    }
                case "2":
                    {
                        dict.LanguageID = 2;
                        break;
                    }
                case "3":
                    {
                        dict.LanguageID = 3;
                        break;
                    }
                default:
                    break;
            }
            LangControl_Login();
            Lang_nav_control();
        }
    }
}
