using LDAv2.Controller;
using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for SearchPanel.xaml
    /// </summary>
    public partial class SearchPanel : UserControl
    {
        private Grid grid;
        Dictionary dict = new Dictionary();
        public SearchPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            SetSearchBar();
            Search_list.ItemsSource = MeasureShort.GetSearched(SearchData());
            LangControl_Searchpanel();

        }
        private List<string> SearchData()
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
        void SetSearchBar()
        {
            try
            {
                List<Search> list = Session.SearchParam;

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
        void SetSearchParam()
        {
            bool allapot_seged = false;
            if(allapot_check.IsChecked == true)
            {
                allapot_seged = true;
            }
            List<Search> list = new List<Search>();
            list.Add(new Search {
                cikkszam = cikkszam_srcinp.Text,
                charge = charge_srcinp.Text,
                szallito = szallito_srcinp.Text,
                anyagnev = anyagnev_srcinp.Text,
                beerk_datum = beerk_srcinp.Text,
                allapot = allapot_seged
            });
            Session.SearchParam = list;
        }
        private async void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int fisrtLength = textbox.Text.Length;

            await Task.Delay(250);
            if (fisrtLength == textbox.Text.Length)
            {
                Search_list.ItemsSource = MeasureShort.GetSearched(SearchData());
                SetSearchParam();
            }
        }

        private void AllapotChecked(object sender, RoutedEventArgs e)
        {
            Search_list.ItemsSource = MeasureShort.GetSearched(SearchData());
        }

        private void MeasureOpenClick(object sender, RoutedEventArgs e)
        {
            DataPanel dataPanel;
            Button btn = sender as Button;
            MeasureShort item = btn.DataContext as MeasureShort;
            Session.CikkszamID = item.id;
            Session.ChargeID = item.charge_id;
            Session.BedatumID = item.beerk_datum;
            SetSearchParam();
            grid.Children.Clear();
            grid.Children.Add(dataPanel = new DataPanel(grid));
        }

        private void RefreshSearchClick(object sender, RoutedEventArgs e)
        {
            cikkszam_srcinp.Text = "";
            charge_srcinp.Text = "";
            szallito_srcinp.Text = "";
            anyagnev_srcinp.Text = "";
            beerk_srcinp.Text = "";
            allapot_check.IsChecked = false;
            SetSearchParam();
            Search_list.ItemsSource = MeasureShort.GetSearched(SearchData());
        }

        private void MeasuereDelete(object sender, RoutedEventArgs e)
        {
            MenuItem raw = sender as MenuItem;
            MeasureShort data = raw.DataContext as MeasureShort;
            Charge.Delete(data.charge_id);
            Search_list.ItemsSource = MeasureShort.GetSearched(SearchData());
        }
        private void LangControl_Searchpanel()
        {
            allapot_check.Content = dict.Word(109);
            cikkszam_label.Text = dict.Word(15);
            charge_label.Text = dict.Word(16);
            szallito_label.Text = dict.Word(18);
            anyagnev_label.Text = dict.Word(19);
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
            LangControl_Searchpanel();
            Lang_nav_control();
        }
    }
}
