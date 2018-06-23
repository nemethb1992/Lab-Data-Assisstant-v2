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
            list.Add(utomunka_inp);
            list.Add(utokalapacs_inp);
            list.Add(suruseg_inp);

            list.Add(anyagtipus_inp);
            list.Add(pc_inp);
            list.Add(szin_inp);
            list.Add(folyokep_hom_inp);
            list.Add(folyokep_suly_inp);

            list.Add(szak_min);
            list.Add(utes_min);
            list.Add(foly_g_min);
            list.Add(foly_cm_min);
            list.Add(tolt_min);

            list.Add(szak_max);
            list.Add(utes_max);
            list.Add(foly_g_max);
            list.Add(foly_cm_max);
            list.Add(tolt_max);

            list.Add(szak_gy);
            list.Add(utes_gy);
            list.Add(foly_g_gy);
            list.Add(foly_cm_gy);
            list.Add(tolt_gy);

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
        private void cikk_inp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (w_control.Cikk_Checker(cikk_inp.Text))
            {
                cikkszam_check.Visibility = Visibility.Visible;
                Save_Charge_Button.IsEnabled = true;
            }
            else
            {
                cikkszam_check.Visibility = Visibility.Hidden;
                Save_Charge_Button.IsEnabled = false;
            }
        }
        private void NewCikk_inp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewCikk_All_Filled())
            {
                Save_Button.IsEnabled = true;
            }
            else
            {
                Save_Button.IsEnabled = false;
            }
        }
    }
}
