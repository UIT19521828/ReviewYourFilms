using ReviewYourFilms.Models;
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
    /// Interaction logic for ComBanner.xaml
    /// </summary>
    public partial class ComBanner : UserControl
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private DataFilm film;
        private DataBanner banner;
        private string fID;
        public ComBanner nextBanner = null;
        public ComBanner previousBanner = null;
        public ComBanner(DataBanner banner, DataFilm film, string fID)
        {
            InitializeComponent();
            this.banner = banner;
            this.film = film;
            this.fID = fID;
            LoadBanner();
        }

        private void LoadBanner()
        {
            imgBanner.ImageSource = banner.GetImage();
            txtDescipt.Text = film.descript;
            txtTitle.Text = film.name;
            string x = "";
            int i = 0;
            foreach(var item in film.category)
            {
                x += item +", ";
                i++;
                if (i == 3) break;
            }
            x += "...";
            txtGenre.Content = x;
        }

        private void txtTitle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(film, fID);
        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(film, fID);
        }
    }
}
