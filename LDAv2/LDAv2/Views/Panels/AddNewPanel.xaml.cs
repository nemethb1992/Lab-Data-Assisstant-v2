using LDAv2.Controller;
using LDAv2.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LDAv2.Views.Panels
{
    /// <summary>
    /// Interaction logic for AddNewPanel.xaml
    /// </summary>
    public partial class AddNewPanel : UserControl
    {
        private Grid grid;
        Dictionary language = new Dictionary();

        public AddNewPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            StartUp();
            LangControl_AddNewpanel();
        }
        private void StartUp()
        {
            szallito_cbx.ItemsSource = Beszallito.Get();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private List<TextBox> Cikk_Input_Collector()
        {
            List<TextBox> list = new List<TextBox>();

            list.Add(cikkszam_inp);
            
            list.Add(anyagnev_inp);
            list.Add(anyagtipus_inp);
            list.Add(pc_inp);
            //list.Add(utomunka_inp);

            list.Add(folyokep_hom_inp);
            list.Add(utokalapacs_inp);
            list.Add(folyokep_suly_inp);
            list.Add(suruseg_inp);
            list.Add(szin_inp);

            list.Add(szak_min);
            list.Add(szak_max);
            list.Add(utes_min);
            list.Add(utes_max);
            list.Add(foly_g_min);
            list.Add(foly_g_max);
            list.Add(foly_cm_min);
            list.Add(foly_cm_max);
            list.Add(tolt_min);
            list.Add(tolt_max);


            //list.Add(szak_gy);
            //list.Add(utes_gy);
            //list.Add(foly_g_gy);
            //list.Add(foly_cm_gy);
            //list.Add(tolt_gy);

            return list;
        }

        private List<TextBox> Charge_Input_Collector()
        {
            List<TextBox> list = new List<TextBox>();

            list.Add(cikk_inp);
            list.Add(charge_inp);
            list.Add(beerk_inp);
            list.Add(utolso_meres_inp);
            list.Add(kw_inp);
            list.Add(megjegyzes_inp);

            return list;
        }
        private bool NewCikk_All_Filled()
        {
            bool filled = true;
            foreach (var item in Cikk_Input_Collector())
            {
                if (item.Text.Length == 0 || szallito_cbx.SelectedItem == null)
                {
                    filled = false;
                    break;
                }
            }
            return filled;
        }
        private void NewCharge_inp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Cikk.IsExists(cikk_inp.Text))
            {
                cikkszam_check.Visibility = Visibility.Visible;
                if (charge_inp.Text.Length > 0 && beerk_inp.Text.Length > 0 && utolso_meres_inp.Text.Length > 0 && kw_inp.Text.Length > 0)
                {
                    Save_Charge_Button.IsEnabled = true;
                }
                else
                {
                    Save_Charge_Button.IsEnabled = false;
                }
            }
            else
            {
                cikkszam_check.Visibility = Visibility.Hidden;
                Save_Charge_Button.IsEnabled = false;
            }
        }
        private void NewCikk_inp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Cikk.IsExists(cikkszam_inp.Text))
            {
                cikkszam2_check.Visibility = Visibility.Hidden;
                if (NewCikk_All_Filled())
                {
                    Save_Button.IsEnabled = true;
                }
                else
                {
                    Save_Button.IsEnabled = false;
                }
            }
            else
            {
                Save_Button.IsEnabled = false;
                cikkszam2_check.Visibility = Visibility.Visible;
            }
        }

        private void Cikk_Save_Button_Click(object sender, RoutedEventArgs e)
        {
            string utomunka = "0";
            if(utomunka_inp.IsChecked == true)
            {
                utomunka ="1";
            }
            List<Cikk> list = new List<Cikk>();
            List<TextBox> tb_list = Cikk_Input_Collector();
            list.Add(new Cikk {
                cikkszam = tb_list[0].Text,
                szallito = szallito_cbx.SelectedItem.ToString(),
                anyag_nev = tb_list[1].Text,
                anyag_tipus = tb_list[2].Text,
                profit_center = tb_list[3].Text,
                utomun_metszve = utomunka,
                folyokep_homerseklet = tb_list[4].Text,
                utokalapacs_meret_j = tb_list[5].Text,
                folyokep_terheles_kg = tb_list[6].Text,
                suruseg = tb_list[7].Text,
                szin = tb_list[8].Text,
                szakszig_min = tb_list[9].Text,
                szakszig_max = tb_list[10].Text,
                utesallosag_min = tb_list[11].Text,
                utesallosag_max = tb_list[12].Text,
                folyokep_min_g = tb_list[13].Text,
                folyokep_max_g = tb_list[14].Text,
                folyokep_min_cm = tb_list[15].Text,
                folyokep_max_cm = tb_list[16].Text,
                toltoanyag_min = tb_list[17].Text,
                toltoanyag_max = tb_list[18].Text,
            });
            Cikk.Insert(list);
            foreach (var item in tb_list)
            {
                item.Text = "";
            }
            utomunka_inp.IsChecked = false;
        }

        private void Charge_Save_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Charge> list = new List<Charge>();
            List<TextBox> tb_list = Charge_Input_Collector();
            list.Add(new Charge
            {
                charge_cikkszam = tb_list[0].Text,
                charge = tb_list[1].Text,
                beerk_datum = tb_list[2].Text,
                ut_meres_datum = tb_list[3].Text,
                kw = tb_list[4].Text,
                megjegyzes = tb_list[5].Text
            });
            Charge.PartialInsert(list);
            foreach (var item in tb_list)
            {
                item.Text = "";
            }

        }
        private void LangControl_AddNewpanel()
        {
            big_label1.Text = language.Word(112);
            big_label2.Text = language.Word(113);
            Save_Button.Content = language.Word(48);
            cikkszam2_label.Text = language.Word(15);
            szallito_label.Text = language.Word(18);
            anyagnev_label.Text = language.Word(19);
            utokalapacs_label.Text = language.Word(43);
            suruseg_label.Text = language.Word(26);
            szakszigmin_label.Text = language.Word(28);
            charpymin_label.Text = language.Word(30);
            folyokepming_label.Text = language.Word(32);
            folyokepmincm_label.Text = language.Word(34);
            toltoanyagmin_label.Text = language.Word(36);

            anyagtipus_label.Text = language.Word(19);
            pc_label.Text = language.Word(21);
            folyhom_label.Text = language.Word(23);
            folysuly_label.Text = language.Word(25);
            szin.Text = language.Word(27);
            szakszigmax_label.Text = language.Word(29);
            charpymax_label.Text = language.Word(31);
            folyokepmaxg_label.Text = language.Word(33);
            folyokepmaxcm_label.Text = language.Word(35);
            toltoanyagmax_label.Text = language.Word(37);
            utomunka_inp.Content = language.Word(22);
            Save_Button.Content = language.Word(48);
            Save_Charge_Button.Content = language.Word(48);

            cikkszam1_label.Text = language.Word(15);
            charge_label.Text = language.Word(16);
            beerk_label.Text = language.Word(17);
            utmeres_label.Text = language.Word(38);
            kw_label.Text = language.Word(39);
            megjegyzes_label.Text = language.Word(47);
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
                        language.LanguageID = 1;
                        break;
                    }
                case "2":
                    {
                        language.LanguageID = 2;
                        break;
                    }
                case "3":
                    {
                        language.LanguageID = 3;
                        break;
                    }
                default:
                    break;
            }
            LangControl_AddNewpanel();
            Lang_nav_control();
        }
    }
}
