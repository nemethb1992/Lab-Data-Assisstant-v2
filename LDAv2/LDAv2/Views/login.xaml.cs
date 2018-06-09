﻿using LDAv2.Controller;
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
        public login(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            BootMethods();
            dbConnectionOpener();
        }
        void dbConnectionOpener()
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
            if (lcontrol.UserValider_MySql(Luser_tbx.Text))
            {
                UserRemember();
                session.UserData = lcontrol.UserSessionDataList(Luser_tbx.Text);
                session.tartomanyi = Luser_tbx.Text;

                //Main mw = new Main();
                //mw.Show();
                //var window = Window.GetWindow(this);
                //window.Close();
            }

            else
            {
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
    }
}
