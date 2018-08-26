using LDAv2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ActivityPanel.xaml
    /// </summary>
    public partial class ActivityPanel : UserControl
    {

        //Thread SearchThread = new Thread(new ThreadStart(SearchMethod));
        admin_control a_control = new admin_control();
        language_control L = new language_control();
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
            activity_list.ItemsSource = a_control.Aktivitas_List(Search_Value_Collector());
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
            felhasznalo_label.Text = L.Word(7);
            muvelet_label.Text = L.Word(96);
            muveletdat_label.Text = L.Word(97);

            cikkszam_label.Text = L.Word(15);
            charge_label.Text = L.Word(16);
            beerk_label.Text = L.Word(17);
        }
    }
}
