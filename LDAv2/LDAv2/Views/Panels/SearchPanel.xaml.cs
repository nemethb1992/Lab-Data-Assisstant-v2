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
            //Search_list.ItemsSource = w_control.Measure_Compact_Query();
        }
    }
}
