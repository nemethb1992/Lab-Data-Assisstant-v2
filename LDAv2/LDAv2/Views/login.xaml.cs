using LDAv2.Controller;
using LDAv2.Views.Windows;
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

namespace LDAv2.Views
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : UserControl
    {
        private Grid grid;
        login_control lcontrol = new login_control();
        Session session = new Session();
        dbEntities dbE = new dbEntities();
        language_control L = new language_control();
        public login(Grid grid)
        {
            L.LanguageID = 3;
            InitializeComponent();
            this.grid = grid;
            BootMethods();
            dbConnectionOpener();
            LangControl_Login();
            //MessageBox.Show(L.Word(10));
        }
        private string teststring()
        {
            return "Sikerült!";
        }
        private void dbConnectionOpener()
        {
            if (!dbE.dbOpen())
            {
                LoginSign.Text = "Nincs adatkapcsolat!";
            }
        }
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            enterApplication();
        }

        private void Luser_tbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            enterApplication();
        }

        private void Lpass_pwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            enterApplication();
        }
        private void BootMethods()
        {
            string user = lcontrol.GetRememberedUser();
            if (user != "")
            {
                Luser_tbx.Text = user;
                login_cbx.IsChecked = true;
            }
            else
            {
                login_cbx.IsChecked = false;
            }
        }
        private void UserRemember()
        {
            if (login_cbx.IsChecked == true)
            {
                lcontrol.WriteRememberedUser(Luser_tbx.Text);
            }
            else
            {
                lcontrol.DeleteRememberedUser();
            }
        }
        private void enterApplication()
        {


            //if (lcontrol.userValidation(Luser_tbx.Text, Lpass_pwd.Password))
            //{
            if (lcontrol.UserValider_MySql(Luser_tbx.Text, Lpass_pwd.Password))
            {
                UserRemember();
                session.UserData = lcontrol.UserSessionDataList(Luser_tbx.Text, Lpass_pwd.Password);
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
            LoginSign.Text = L.Word(104);
            login_cbx.Content = L.Word(105);
            reg_btn.Text = L.Word(10);
            btn_login.Content = L.Word(9);
        }
    }
}
