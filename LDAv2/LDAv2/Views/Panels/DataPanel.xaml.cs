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
            test();
        }
        private void test()
        {
            MessageBox.Show(w_control.CikkszamID + "   " + w_control.ChargeID + "  " + w_control.BedatumID);
        }
    }
}
