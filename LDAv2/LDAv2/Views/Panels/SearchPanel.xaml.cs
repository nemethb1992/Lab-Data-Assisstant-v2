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

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());
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
            w_control.CikkszamID = item.cikkszam;
            w_control.ChargeID = item.charge;
            w_control.BedatumID = item.beerk_datum;
            grid.Children.Clear();
            grid.Children.Add(dataPanel = new DataPanel(grid));
        }
    }
}
