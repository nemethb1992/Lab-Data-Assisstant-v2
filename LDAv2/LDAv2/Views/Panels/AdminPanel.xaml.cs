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
using static LDAv2.Model.UserDataModel;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : UserControl
    {
        private Grid grid;
        admin_control a_control = new admin_control();
        Language L = new Language();
        public AdminPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            UsersListLorader();
            LangControl_Adminpanel();
        }
        void UsersListLorader()
        {
            List<UserDataModel> li = a_control.Admin_User_Datasource();
            foreach (var item in li)
            {
                if(item.valid == 1)
                {
                    if(item.admintag == 1)
                    {
                        item.allapot_megnev = "Admin";
                    }
                    else
                    {
                        if (item.auth == 1)
                        {
                            item.allapot_megnev = "Olvasó";
                        }
                        if (item.auth == 2)
                        {
                            item.allapot_megnev = "Író / Olvasó";
                        }
                    }
                }
                else
                {
                    item.allapot_megnev = "Blokkolt";
                }
            }
            Users_list.ItemsSource = li;

        }

        private void User_List_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid gr = sender as Grid;
            UserDataModel data = gr.DataContext as UserDataModel;
            List<UserDataModel> li = a_control.SelectedUserDataSource(data.user_id);

            a_control.User_ID = li[0].user_id;
            User_data_inp_1.Text = li[0].username;
            User_data_inp_2.Text = li[0].real_name;
            User_data_inp_3.Text = li[0].email;
            if(li[0].valid == 1)
            {
                User_data_check_1.IsChecked = true;
            }
            else
            {
                User_data_check_1.IsChecked = false;
            }
            if (li[0].auth == 1)
            {
                User_data_check_3.IsChecked = true;
                User_data_check_4.IsChecked = false;
            }
            if (li[0].auth == 2)
            {
                User_data_check_4.IsChecked = true;
                User_data_check_3.IsChecked = false;
            }
            if (li[0].admintag == 1)
            {
                User_data_check_2.IsChecked = true;
                User_data_check_3.IsChecked = false;
                User_data_check_4.IsChecked = true;
            }
            else
            {
                User_data_check_2.IsChecked = false;
            }
        }

        private void User_Modification_Save_Click(object sender, RoutedEventArgs e)
        {
            List<UserDataModel> li = new List<UserDataModel>();
            int valid,auth = 1,admintag;
            if(User_data_check_1.IsChecked == true)
            {
                valid = 1;
            }
            else
            {
                valid = 0;
            }
            if (User_data_check_3.IsChecked == true)
            {
                auth = 1;
            }
            if (User_data_check_4.IsChecked == true)
            {
                auth = 2;
            }
            if (User_data_check_2.IsChecked == true)
            {
                admintag = 1;
                auth = 2;
            }
            else
            {
                admintag = 0;
            }
            li.Add(new UserDataModel
            {
                user_id = a_control.User_ID,
                username = User_data_inp_1.Text,
                real_name = User_data_inp_2.Text,
                email = User_data_inp_3.Text,
                valid = valid,
                auth = auth,
                admintag = admintag
            });


            a_control.SelectedUserModification(li);
            UsersListLorader();
        }

        private void User_Modification_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (User_data_inp_1.Text.Length > 0 && User_data_inp_2.Text.Length > 0 && User_data_inp_3.Text.Length > 0)
            {
                User_Modification_Save_Btn.IsEnabled = true;
            }
            else
            {
                User_Modification_Save_Btn.IsEnabled = false;
            }
        }

        private void User_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            switch (check.Tag)
            {
                case "1":
                    {
                        User_data_check_4.IsChecked = false;
                        break;
                    }
                case "2":
                    {
                        User_data_check_3.IsChecked = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void User_Delete(object sender, RoutedEventArgs e)
        {
            MenuItem raw = sender as MenuItem;
            UserDataModel data = raw.DataContext as UserDataModel;
            a_control.Delete_User(data.user_id);
            UsersListLorader();
        }
        private void LangControl_Adminpanel()
        {
            felhasznalo_label.Text = L.Word(7);

            teljesnev_label.Text = L.Word(11);
            email_label.Text = L.Word(13);
            jogosultsag_label.Text = L.Word(51);
            felhasznalok_label.Text = L.Word(110);
            beallitasok_label.Text = L.Word(111);

            User_data_check_1.Content = L.Word(49);
            User_data_check_2.Content = L.Word(50);
            User_data_check_3.Content = L.Word(101);
            User_data_check_4.Content = L.Word(102);
            User_Modification_Save_Btn.Content = L.Word(48);
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
                        L.LanguageID = 1;
                        break;
                    }
                case "2":
                    {
                        L.LanguageID = 2;
                        break;
                    }
                case "3":
                    {
                        L.LanguageID = 3;
                        break;
                    }
                default:
                    break;
            }
            LangControl_Adminpanel();
            Lang_nav_control();
        }
    }
}
