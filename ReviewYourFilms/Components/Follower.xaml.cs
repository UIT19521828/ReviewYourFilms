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
        private DataUser data;
        public Follower(DataUser data)
        {          
            InitializeComponent();
            this.data = data;
            DataContext = data;
            LoadData();
        }
        private void LoadData()
        {
            imgAvatar.ImageSource = data.GetImage();
        }
    }
}
