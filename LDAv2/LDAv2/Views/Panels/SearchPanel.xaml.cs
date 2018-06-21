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
using static LDAv2.Controller.workpanel_control;
using static LDAv2.Model.workpanel_model;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for SearchPanel.xaml
    /// </summary>
    public partial class SearchPanel : UserControl
    {
        private Grid grid;
        workpanel_control w_control = new workpanel_control();
        public SearchPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            Read_SearchParams();
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());

        }
        private List<string> Search_Data_Collector()
        {
            List<string> list = new List<string>();
            string allapot = "0";
            if (allapot_check.IsChecked == true)
            {
                allapot = "1";
            }
            list.Add(cikkszam_srcinp.Text);
            list.Add(charge_srcinp.Text);
            list.Add(szallito_srcinp.Text);
            list.Add(anyagnev_srcinp.Text);
            list.Add(beerk_srcinp.Text);
            list.Add(allapot);

            return list;
        }
        void Read_SearchParams()
        {
            try
            {
                List<Search_Params> list = w_control.SearchParam;

                cikkszam_srcinp.Text = list[0].cikkszam;
                charge_srcinp.Text = list[0].charge;
                szallito_srcinp.Text = list[0].szallito;
                anyagnev_srcinp.Text = list[0].anyagnev;
                beerk_srcinp.Text = list[0].beerk_datum;
                allapot_check.IsChecked = list[0].allapot;
            }
            catch (Exception)
            {
                cikkszam_srcinp.Text = "";
                charge_srcinp.Text = "";
                szallito_srcinp.Text = "";
                anyagnev_srcinp.Text = "";
                beerk_srcinp.Text = "";
                allapot_check.IsChecked = false;
            }

        }
        void Write_SearchParams()
        {
            bool allapot_seged = false;
            if(allapot_check.IsChecked == true)
            {
                allapot_seged = true;
            }
            List<Search_Params> list = new List<Search_Params>();
            list.Add(new Search_Params {
                cikkszam = cikkszam_srcinp.Text,
                charge = charge_srcinp.Text,
                szallito = szallito_srcinp.Text,
                anyagnev = anyagnev_srcinp.Text,
                beerk_datum = beerk_srcinp.Text,
                allapot = allapot_seged
            });
            w_control.SearchParam = list;
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());
            Write_SearchParams();
        }

        private void allapot_check_Checked(object sender, RoutedEventArgs e)
        {
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());
        }

        private void Measure_Open_Click(object sender, RoutedEventArgs e)
        {
            DataPanel dataPanel;
            Button btn = sender as Button;
            Measure_Compact_Struct item = btn.DataContext as Measure_Compact_Struct;
            w_control.CikkszamID = item.id;
            w_control.ChargeID = item.charge_id;
            w_control.BedatumID = item.beerk_datum;
            Write_SearchParams();
            grid.Children.Clear();
            grid.Children.Add(dataPanel = new DataPanel(grid));
        }

        private void Refresh_Search_Click(object sender, RoutedEventArgs e)
        {
            cikkszam_srcinp.Text = "";
            charge_srcinp.Text = "";
            szallito_srcinp.Text = "";
            anyagnev_srcinp.Text = "";
            beerk_srcinp.Text = "";
            allapot_check.IsChecked = false;
            Write_SearchParams();
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());
        }
    }
}
