using LDAv2.Controller;
using LDAv2.Views.Panels;
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
using System.Windows.Shapes;

namespace LDAv2.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private SearchPanel searchPanel;
        private AddNewPanel addNewPanel;
        private ActivityPanel activityPanel;
        private AdminPanel adminPanel;
        public WorkWindow()
        {
            InitializeComponent();
            sgrid.Children.Add(searchPanel = new SearchPanel(sgrid));
            DataPanel_Setting_Up();
        }
        void DataPanel_Setting_Up()
        {
            Session sess = new Session();
            if (sess.UserData[0].admintag != 1)
            {
                if (sess.UserData[0].auth == 1)
                {
                    mw_btn2.Visibility = Visibility.Hidden;
                    mw_btn3.Visibility = Visibility.Hidden;
                    mw_btn4.Visibility = Visibility.Hidden;
                }
                else
                {
                    mw_btn3.Visibility = Visibility.Hidden;
                    mw_btn4.Visibility = Visibility.Hidden;
                }
            }
        }
        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            workpanel_control w_control = new workpanel_control();
            MainWindow mw = new MainWindow();
            var window = Window.GetWindow(this);
            if (w_control.SearchParam != null)
            {
                w_control.SearchParam.Clear();
            }
            window.Close();
            mw.Show();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "1":
                    sgrid.Children.Clear();
                    sgrid.Children.Add(searchPanel = new SearchPanel(sgrid));
                    break;
                case "2":
                    sgrid.Children.Clear();
                    sgrid.Children.Add(addNewPanel = new AddNewPanel(sgrid));
                    break;
                case "3":
                    sgrid.Children.Clear();
                    sgrid.Children.Add(activityPanel = new ActivityPanel(sgrid));
                    break;
                case "4":
                    sgrid.Children.Clear();
                    sgrid.Children.Add(adminPanel = new AdminPanel(sgrid));
                    break;
                default:
                    break;
            }
        }

    
    }
}
