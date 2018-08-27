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
        language_control L = new language_control();
        public DataPanel(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            DataPanel_Setting_Up();
            LangControl_Datapanel();
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
            for (int i = 1; i < 37; i++)
            {
                tbx = (TextBox)this.FindName("DataPanel_" + i.ToString());
                list.Add(tbx.Text);
            }
            if (DataPanel_37.IsChecked == true)
            {
                list.Add("1");
            }
            else
            {
                list.Add("0");
            }
            if (DataPanel_38.IsChecked == true)
            {
                list.Add("1");
            }
            else
            {
                list.Add("0");
            }
                list.Add(DataPanel_26_2.Text);
                list.Add(DataPanel_27_2.Text);
                list.Add(DataPanel_28_2.Text);
                list.Add(DataPanel_29_2.Text);
                list.Add(DataPanel_30_2.Text);
            
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
            DataPanel_37_locker.Visibility = Visibility.Visible;
            DataPanel_38_locker.Visibility = Visibility.Visible;
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
            
            DataPanel_26_2.Text = "";
            DataPanel_27_2.Text = "";
            DataPanel_28_2.Text = "";
            DataPanel_29_2.Text = "";
            DataPanel_30_2.Text = "";

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
        void inputEvaulationColorer(List<Measure_Value> li)
        {
            //if (li[0].val2 == "" || li[0].val2 == "-")
            //{
            //    li[0].val2 = li[0].val1;
            //}
            //var bc = new BrushConverter();
            //string color = "#FFFFFF";
            //try
            //{
            //    Double.TryParse(li[0].min.Replace(".", ","), out double min);
            //    Double.TryParse(li[0].max.Replace(".", ","), out double max);
            //    Double.TryParse(li[0].val1.Replace(".", ","), out double value1);
            //    Double.TryParse(li[0].val2.Replace(".", ","), out double value2);

            //    double finalValue = (value1 + value2) / 2;
            //    if (finalValue > (min + 0.00000000) && finalValue < (max + 0.00000000))
            //    {
            //        color = "#ccffcc";
            //    }
            //    else if (finalValue == (min + 0.00000000) || finalValue == (max + 0.00000000))
            //    {
            //        color = "#fffabb";
            //    }
            //    else if (finalValue < (min + 0.00000000) || finalValue > (max + 0.00000000))
            //    {
            //        color = "#ffcccc";
            //    }
            //}
            //catch (Exception)
            //{
            //    color = "#FFFFFF";
            //}
            //input.Background = (Brush)bc.ConvertFrom(color);
            //if (input2 != null)
            //{
            //    input2.Background = (Brush)bc.ConvertFrom(color);
            //}
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

            List<Measure_Full_Struct> li = new List<Measure_Full_Struct>();
            List<string> listr = DataPanel_Value_List();
            //string szakszig = listr[25], utesall = listr[26], folykepg = listr[27], folykepcm = listr[28], tolto = listr[29];
            try
            {
                if (listr[38] == "" || listr[38] == "-")
                    listr[38] = listr[25];
                if (listr[39] == "" || listr[39] == "-")
                    listr[39] = listr[26];
                if (listr[40] == "" || listr[40] == "-")
                    listr[40] = listr[27];
                if (listr[41] == "" || listr[41] == "-")
                    listr[41] = listr[28];
                if (listr[42] == "" || listr[42] == "-")
                    listr[42] = listr[29];

                Double.TryParse(listr[25].Replace(".", ","), out double szakszig_1);
                Double.TryParse(listr[26].Replace(".", ","), out double utesallosag_1);
                Double.TryParse(listr[27].Replace(".", ","), out double folyokep_g_1);
                Double.TryParse(listr[28].Replace(".", ","), out double folyokep_cm_1);
                Double.TryParse(listr[29].Replace(".", ","), out double toltoanyag_1);

                Double.TryParse(listr[38].Replace(".", ","), out double szakszig_2);
                Double.TryParse(listr[39].Replace(".", ","), out double utesallosag_2);
                Double.TryParse(listr[40].Replace(".", ","), out double folyokep_g_2);
                Double.TryParse(listr[41].Replace(".", ","), out double folyokep_cm_2);
                Double.TryParse(listr[42].Replace(".", ","), out double toltoanyag_2);

                listr[25] = ((szakszig_1 + szakszig_2) / 2).ToString();
                listr[26] = ((utesallosag_1 + utesallosag_2) / 2).ToString();
                listr[27] = ((folyokep_g_1 + folyokep_g_2) / 2).ToString();
                listr[28] = ((folyokep_cm_1 + folyokep_cm_2) / 2).ToString();
                listr[29] = ((toltoanyag_1 + toltoanyag_2) / 2).ToString();



            }
            catch (Exception)
            {
                //    if (listr[38] == "" || listr[38] == "-")
                //        listr[38] = listr[25];
                //    if (listr[39] == "" || listr[39] == "-")
                //        listr[39] = listr[26];
                //    if (listr[40] == "" || listr[40] == "-")
                //        listr[40] = listr[27];
                //    if (listr[41] == "" || listr[41] == "-")
                //        listr[41] = listr[28];
                //    if (listr[42] == "" || listr[42] == "-")
                //        listr[42] = listr[29];
            }
            li.Add(new Measure_Full_Struct
            {
                cikkszam = listr[0],
                szallito = listr[1],
                anyag_nev = listr[2],
                utokalapacs_meret_j = listr[3],
                suruseg = listr[4],
                szakszig_min = listr[5],
                utesallosag_min = listr[6],
                folyokep_min_g = listr[7],
                folyokep_min_cm = listr[8],
                toltoanyag_min = listr[9],

                charge = listr[10],
                anyag_tipus = listr[11],
                profit_center = listr[12],
                folyokep_homerseklet = listr[13],
                folyokep_terheles_kg = listr[14],
                szin = listr[15],
                szakszig_max = listr[16],
                utesallosag_max = listr[17],
                folyokep_max_g = listr[18],
                folyokep_max_cm = listr[19],
                toltoanyag_max = listr[20],
                
                beerk_datum = listr[21],
                ut_meres_datum = listr[22],
                kw = listr[23],
                viztartalom = listr[24],

                szakszig = listr[25],
                utesallosag = listr[26],
                folyokep_g = listr[27],
                folyokep_cm = listr[28],
                toltoanyag = listr[29],

                megjegyzes = listr[30],
                szakszig_gy = listr[31],
                utesallosag_gy = listr[32],
                folyokep_g_gy = listr[33],
                folyokep_cm_gy = listr[34],
                toltoanyag_gy = listr[35],
                utomun_metszve = listr[36],
                allapot = listr[37],
            });
            w_control.Measure_UPDATE_MySQL(li);
            DataPanel_MeasureDat_Loud_Up();
        }

        private void Measure_Valider_TextChanger(object sender, TextChangedEventArgs e)
        {
            string min_s="", max_s="", val1_s="", val2_s="";
            TextBox tbx = sender as TextBox;
            TextBox input1 = tbx;
            switch (tbx.Tag)
            {

                case "1":
                    {
                        input1 = DataPanel_26;
                        min_s = DataPanel_6.Text;
                        max_s = DataPanel_17.Text;
                        val1_s = DataPanel_26.Text;
                        val2_s = DataPanel_26_2.Text;
                        break;
                    }

                case "2":
                    {
                        input1 = DataPanel_27;
                        min_s = DataPanel_7.Text;
                        max_s = DataPanel_18.Text;
                        val1_s = DataPanel_27.Text;
                        val2_s = DataPanel_27_2.Text;
                        break;
                    }

                case "3":
                    {
                        input1 = DataPanel_28;
                        min_s = DataPanel_8.Text;
                        max_s = DataPanel_19.Text;
                        val1_s = DataPanel_28.Text;
                        val2_s = DataPanel_28_2.Text;
                        break;
                    }

                case "4":
                    {
                        input1 = DataPanel_29;
                        min_s = DataPanel_9.Text;
                        max_s = DataPanel_20.Text;
                        val1_s = DataPanel_29.Text;
                        val2_s = DataPanel_29_2.Text;
                        break;
                    }

                case "5":
                    {
                        input1 = DataPanel_30;
                        min_s = DataPanel_10.Text;
                        max_s = DataPanel_21.Text;
                        val1_s = DataPanel_30.Text;
                        val2_s = DataPanel_30_2.Text;
                        break;
                    }
                default:
                    break;
            }
            if (val2_s == "" || val2_s == "-")
            {
                val2_s = val1_s;
            }
            var bc = new BrushConverter();
            string color = "#FFFFFF";
            try
            {
                Double.TryParse(min_s.Replace(".", ","), out double min);
                Double.TryParse(max_s.Replace(".", ","), out double max);
                Double.TryParse(val1_s.Replace(".", ","), out double val1);
                Double.TryParse(val2_s.Replace(".", ","), out double val2);

                double finalValue = (val1 + val2) / 2;
                if (finalValue > (min + 0.00000000) && finalValue < (max + 0.00000000))
                {
                    color = "#ccffcc";
                }
                else if (finalValue == (min + 0.00000000) || finalValue == (max + 0.00000000))
                {
                    color = "#fffabb";
                }
                else if (finalValue < (min + 0.00000000) || finalValue > (max + 0.00000000))
                {
                    color = "#ffcccc";
                }
            }
            catch (Exception)
            {
                color = "#FFFFFF";
            }
            input1.Background = (Brush)bc.ConvertFrom(color);
            //if (input2 != null)
            //{
            //    input2.Background = (Brush)bc.ConvertFrom(color);
            //}
        }
        private void LangControl_Datapanel()
        {
            big_label.Text = L.Word(1);
            Save_Button.Content = L.Word(48);
            cikkszam_label.Text = L.Word(15);
            szallito_label.Text = L.Word(18);
            anyagnev_label.Text = L.Word(19);
            utomunka_label.Text = L.Word(22);
            utokalapacs_label.Text = L.Word(43);
            suruseg_label.Text = L.Word(26);
            szakszigmin_label.Text = L.Word(28);
            charpymin_label.Text = L.Word(30);
            folyokepming_label.Text = L.Word(32);
            folyokepmincm_label.Text = L.Word(34);
            toltoanyagmin_label.Text = L.Word(36);
            DataPanel_37.Content = L.Word(108);

            charge_label.Text = L.Word(16);
            anyagtipus_label.Text = L.Word(19);
            pc_label.Text = L.Word(21);
            folyhom_label.Text = L.Word(23);
            folysuly_label.Text = L.Word(25);
            szin.Text = L.Word(27);
            szakszigmax_label.Text = L.Word(29);
            charpymax_label.Text = L.Word(31);
            folyokepmaxg_label.Text = L.Word(33);
            folyokepmaxcm_label.Text = L.Word(35);
            toltoanyagmax_label.Text = L.Word(37);

            beerk_label.Text = L.Word(17);
            utmeres_label.Text = L.Word(38);
            kw_label.Text = L.Word(39);
            big2_label.Text = L.Word(106);
            viztartalom_label.Text = L.Word(41);
            szakszig_label.Text = L.Word(42);
            charpy_label.Text = L.Word(43);
            folyokepg_label.Text = L.Word(44);
            folyokepcm_label.Text = L.Word(45);
            toltoanyag_label.Text = L.Word(46);

            allapot_label.Text = L.Word(107);
            megjegyzes_label.Text = L.Word(47);
            szakszigGY_label.Text = L.Word(84);
            charpyGY_label.Text = L.Word(85);
            folyokepgGY_label.Text = L.Word(86);
            folyokepcmGY_label.Text = L.Word(87);
            toltoanyagGY_label.Text = L.Word(88);
            DataPanel_38.Content = L.Word(5);
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
            LangControl_Datapanel();
            Lang_nav_control();
        }
    }
}
