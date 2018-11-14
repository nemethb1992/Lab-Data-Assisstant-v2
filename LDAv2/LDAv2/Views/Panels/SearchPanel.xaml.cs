using LDAv2.Controller;
using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static LDAv2.Controller.workpanel_control;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for SearchPanel.xaml
    /// </summary>
    public partial class SearchPanel : UserControl
    {
        private Grid grid;
        workpanel_control w_control = new workpanel_control();
        Language L = new Language();
        public SearchPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            Read_SearchParams();
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());
            LangControl_Searchpanel();

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
                List<SearchModel> list = w_control.SearchParam;

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
            List<SearchModel> list = new List<SearchModel>();
            list.Add(new SearchModel {
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
            MeasureShortModel item = btn.DataContext as MeasureShortModel;
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

        private void Measuere_Delete(object sender, RoutedEventArgs e)
        {
            MenuItem raw = sender as MenuItem;
            MeasureShortModel data = raw.DataContext as MeasureShortModel;
            w_control.Delete_Charge(data.charge_id);
            Search_list.ItemsSource = w_control.Measure_Compact_Query(Search_Data_Collector());
        }
        private void LangControl_Searchpanel()
        {
            allapot_check.Content = L.Word(109);
            cikkszam_label.Text = L.Word(15);
            charge_label.Text = L.Word(16);
            szallito_label.Text = L.Word(18);
            anyagnev_label.Text = L.Word(19);
            beerk_label.Text = L.Word(17);
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
            LangControl_Searchpanel();
            Lang_nav_control();
        }
    }
}
