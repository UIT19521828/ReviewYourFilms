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

namespace ReviewYourFilms.Components
{
    /// <summary>
    /// Interaction logic for Follower.xaml
    /// </summary>
    public partial class Follower : UserControl
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private DataUser data;
        private string followID;
        public Follower(DataUser data, string followID)
        {          
            InitializeComponent();
            this.data = data;
            this.followID = followID;
            DataContext = data;
            LoadData();
        }
        private void LoadData()
        {
            imgAvatar.ImageSource = data.GetImage();
        }

        private void txtName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.followPage.panelProfile.Children.Clear();
            ProfileUser pu = new ProfileUser(followID, main);
            pu.gridLabel.Visibility = Visibility.Collapsed;
            main.followPage.panelProfile.Children.Add(
                pu);
            pu.Show();
        }
    }
}
