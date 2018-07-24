using LDAv2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddNewPanel.xaml
    /// </summary>
    public partial class AddNewPanel : UserControl
    {
        private Grid grid;
        workpanel_control w_control = new workpanel_control();
        public AddNewPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
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

            list.Add(szallito_inp);
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
                if (item.Text.Length == 0)
                {
                    filled = false;
                    break;
                }
            }
            return filled;
        }
        private void NewCharge_inp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (w_control.Cikk_Checker(cikk_inp.Text))
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
            if (!w_control.Cikk_Checker(cikkszam_inp.Text))
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
            List<Cikk_Struct> list = new List<Cikk_Struct>();
            List<TextBox> tb_list = Cikk_Input_Collector();
            list.Add(new Cikk_Struct {
                cikkszam = tb_list[0].Text,
                szallito = tb_list[1].Text,
                anyag_nev = tb_list[2].Text,
                anyag_tipus = tb_list[3].Text,
                profit_center = tb_list[4].Text,
                utomun_metszve = utomunka,
                folyokep_homerseklet = tb_list[5].Text,
                utokalapacs_meret_j = tb_list[6].Text,
                folyokep_terheles_kg = tb_list[7].Text,
                suruseg = tb_list[8].Text,
                szin = tb_list[9].Text,
                szakszig_min = tb_list[10].Text,
                szakszig_max = tb_list[11].Text,
                utesallosag_min = tb_list[12].Text,
                utesallosag_max = tb_list[13].Text,
                folyokep_min_g = tb_list[14].Text,
                folyokep_max_g = tb_list[15].Text,
                folyokep_min_cm = tb_list[16].Text,
                folyokep_max_cm = tb_list[17].Text,
                toltoanyag_min = tb_list[18].Text,
                toltoanyag_max = tb_list[19].Text,
            });
            w_control.Cikk_INSERT_MySQL(list);
            foreach (var item in tb_list)
            {
                item.Text = "";
            }
            utomunka_inp.IsChecked = false;
        }

        private void Charge_Save_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Charge_Struct> list = new List<Charge_Struct>();
            List<TextBox> tb_list = Charge_Input_Collector();
            list.Add(new Charge_Struct
            {
                charge_cikkszam = tb_list[0].Text,
                charge = tb_list[1].Text,
                beerk_datum = tb_list[2].Text,
                ut_meres_datum = tb_list[3].Text,
                kw = tb_list[4].Text,
                megjegyzes = tb_list[5].Text
            });
            w_control.Charge_INSERT_MySQL(list);
            foreach (var item in tb_list)
            {
                item.Text = "";
            }

        }

        private void Save_Charge_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
