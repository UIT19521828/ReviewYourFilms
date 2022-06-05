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
using System.Windows.Threading;
using Google.Cloud.Firestore;


namespace ReviewYourFilms
{
    public partial class MainWindow : Window
    {
        private CornerRadius crNor = new CornerRadius(10);
        private CornerRadius crMax = new CornerRadius(0);
        private CornerRadius crSecond = new CornerRadius(0, 0, 10, 10);
        public HomePage homePage = new HomePage();
        public WatchList watchList = new WatchList();
        public TopOfApp topOfApp = new TopOfApp();
        public SearchPage searchPage = new SearchPage();

        public FirestoreDb db;

        public MainWindow()
        {
            InitializeComponent();    
            db = AccountManager.Instance().LoadDB();
            this.MaxHeight = SystemParameters.WorkArea.Height + 7;
            this.MaxWidth = SystemParameters.WorkArea.Width + 7;
        }       

        private void BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonMax_Click(object sender, RoutedEventArgs e)
        {
            ChangeStateWind();
        }
        private void ChangeStateWind()
        {
            if (this.WindowState != WindowState.Maximized)
            {
                mainBorder.CornerRadius = crMax;
                secondBorder.CornerRadius = crMax;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                mainBorder.CornerRadius = crNor;
                secondBorder.CornerRadius = crSecond;
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult rs = (
                System.Windows.Forms.DialogResult)MessageBox.Show("Do you want to Exit App?"
                , "Exit App?", MessageBoxButton.YesNo);
            if (rs == System.Windows.Forms.DialogResult.Yes)
                Environment.Exit(0);
        }

        private void OpenMenuBoard(object sender, RoutedEventArgs e)
        {
            if(menuBoard.Visibility == Visibility.Visible) 
                menuBoard.Visibility = Visibility.Collapsed;
            else menuBoard.Visibility = Visibility.Visible;
        }
        private void OpenAccount(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeStateWind();
            menuBoard.Visibility = Visibility.Collapsed;
            btnHomeP.IsChecked = true;
            NavHost.Content = homePage;           
        }
        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            NavHost.Content = homePage;
        }

        private void WatchL_Click(object sender, RoutedEventArgs e)
        {
            NavHost.Content = watchList;
        }

        private void Top100_Click(object sender, RoutedEventArgs e)
        {
            NavHost.Content = topOfApp;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavHost.Content = searchPage;
        }

        private void Followed_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
