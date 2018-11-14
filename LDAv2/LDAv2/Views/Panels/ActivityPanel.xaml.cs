using LDAv2.Controller;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for ActivityPanel.xaml
    /// </summary>
    public partial class ActivityPanel : UserControl
    {

        //Thread SearchThread = new Thread(new ThreadStart(SearchMethod));
        Admin admin = new Admin();
        Dictionary dict = new Dictionary();
        private  Grid grid;
        public ActivityPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            List_Loader();
            LangControl_Activitypanel();
            //Search_list.ItemsSource = w_control.Measure_Compact_Query();

        }

        private void List_Loader()
        {
            activity_list.ItemsSource = admin.GetActivityList(Search_Value_Collector());
        }
        private void Refresh_Search_Click(object sender, RoutedEventArgs e)
        {
            user_srcinp.Text = "";
            muvelet_srcinp.Text = "";
            cikkszam_srcinp.Text = "";
            charge_srcinp.Text = "";
            beerk_dat_srcinp.Text = "";
            muvelet_dat_srcinp.Text = "";
            allapot_check.IsChecked = false;
        }
        private List<string> Search_Value_Collector()
        {
            List<string> list = new List<string>();

            if (allapot_check.IsChecked == true)
            {
                list.Add("1");
            }
            else
            {
                list.Add("0");
            }
            list.Add(user_srcinp.Text);
            list.Add(muvelet_srcinp.Text);
            list.Add(cikkszam_srcinp.Text);
            list.Add(charge_srcinp.Text);
            list.Add(beerk_dat_srcinp.Text);
            list.Add(muvelet_dat_srcinp.Text);
    

            return list;
        }
        //static void SearchMethod()
        //{
        //    ActivityPanel ap = new ActivityPanel(ap2);
        //    Thread.Sleep(500);
        //    ap.List_Loader();
        //}
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            List_Loader();
        }
        private void LangControl_Activitypanel()
        {
            felhasznalo_label.Text = dict.Word(7);
            muvelet_label.Text = dict.Word(96);
            muveletdat_label.Text = dict.Word(97);

            cikkszam_label.Text = dict.Word(15);
            charge_label.Text = dict.Word(16);
            beerk_label.Text = dict.Word(17);
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
            LangControl_Activitypanel();
            Lang_nav_control();
        }
    }
}
