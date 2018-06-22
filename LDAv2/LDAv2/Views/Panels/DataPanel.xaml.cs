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
    /// Interaction logic for DataPanel.xaml
    /// </summary>
    public partial class DataPanel : UserControl
    {
        private Grid grid;
        workpanel_control w_control = new workpanel_control();
        public DataPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            DataPanel_Setting_Up();
        }
        private List<TextBox> DataPanel_TextBox_List()
        {
            TextBox tbx;
            List<TextBox> list = new List<TextBox>();
            for (int i = 1; i < 36; i++)
            {
                tbx = (TextBox)this.FindName("DataPanel_" + i.ToString());
                list.Add(tbx);
            }
            return list;
        }
        private List<string> DataPanel_Value_List()
        {
            TextBox tbx;
            List<string> list = new List<string>();
            for (int i = 1; i < 36; i++)
            {
                tbx = (TextBox)this.FindName("DataPanel_" + i.ToString());
                list.Add(tbx.Text);
            }
            return list;
        }
        void DataPanel_Setting_Up()
        {
            Session sess = new Session();
            if(sess.UserData[0].admintag != 1)
            {
                if(sess.UserData[0].auth == 1)
                {
                    Kategoria_OnlyViewer();
                }
                else
                {
                    Kategoria_Assisstant();
                }
            }
            DataPanel_MeasureDat_Loud_Up();
        }
        private void Kategoria_OnlyViewer()
        {
            foreach (var item in DataPanel_TextBox_List())
            {
                item.IsReadOnly = true;
            }
            DataPanel_37.is
            Save_Button.Visibility = Visibility.Hidden;
        }
        private void Kategoria_Assisstant()
        {
            DataPanel_TextBox_List()[0].IsReadOnly = true;
            DataPanel_TextBox_List()[11].IsReadOnly = true;
            DataPanel_TextBox_List()[22].IsReadOnly = true;
        }

        void DataPanel_MeasureDat_Loud_Up()
        {
            List<Measure_Full_Struct> list = w_control.Measure_Full_Query();
            DataPanel_1.Text = list[0].cikkszam;
            DataPanel_2.Text = list[0].szallito;
            DataPanel_3.Text = list[0].anyag_nev;
            DataPanel_4.Text = list[0].utokalapacs_meret_j;
            DataPanel_5.Text = list[0].suruseg;
            DataPanel_6.Text = list[0].szakszig_min;
            DataPanel_7.Text = list[0].utesallosag_min;
            DataPanel_8.Text = list[0].folyokep_min_g;
            DataPanel_9.Text = list[0].folyokep_min_cm;
            DataPanel_10.Text = list[0].toltoanyag_min;

            DataPanel_11.Text = list[0].charge;
            DataPanel_12.Text = list[0].anyag_tipus;
            DataPanel_13.Text = list[0].profit_center;
            DataPanel_14.Text = list[0].folyokep_homerseklet;
            DataPanel_15.Text = list[0].folyokep_terheles_kg;
            DataPanel_16.Text = list[0].szin;
            DataPanel_17.Text = list[0].szakszig_max;
            DataPanel_18.Text = list[0].utesallosag_max;
            DataPanel_19.Text = list[0].folyokep_max_g;
            DataPanel_20.Text = list[0].folyokep_max_cm;
            DataPanel_21.Text = list[0].toltoanyag_max;

            DataPanel_22.Text = list[0].beerk_datum;
            DataPanel_23.Text = list[0].ut_meres_datum;
            DataPanel_24.Text = list[0].kw;
            DataPanel_25.Text = list[0].viztartalom;
            DataPanel_26.Text = list[0].szakszig;
            DataPanel_27.Text = list[0].utesallosag;
            DataPanel_28.Text = list[0].folyokep_g;
            DataPanel_29.Text = list[0].folyokep_cm;
            DataPanel_30.Text = list[0].toltoanyag;

            DataPanel_31.Text = list[0].megjegyzes;
            DataPanel_32.Text = list[0].szakszig_gy;
            DataPanel_33.Text = list[0].utesallosag_gy;
            DataPanel_34.Text = list[0].folyokep_g_gy;
            DataPanel_35.Text = list[0].folyokep_cm_gy;
            DataPanel_36.Text = list[0].toltoanyag_gy;
            if (list[0].utomun_metszve == "1")
                DataPanel_37.IsChecked = true;
            if (list[0].allapot == "1")
                DataPanel_38.IsChecked = true;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
