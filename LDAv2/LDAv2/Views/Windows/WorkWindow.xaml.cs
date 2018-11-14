using LDAv2.Controller;
using LDAv2.Views.Panels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            if (Session.UserData[0].admintag != 1)
            {
                if (Session.UserData[0].auth == 1)
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
            MainWindow mw = new MainWindow();
            var window = Window.GetWindow(this);
            if (Session.SearchParam != null)
            {
                Session.SearchParam.Clear();
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
