using Google.Cloud.Firestore;
using ReviewYourFilms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for TopOfApp.xaml
    /// </summary>
    public partial class TopOfApp : Page
    {
        private FirestoreDb db = AccountManager.Instance().LoadDB();
        private ComTopFilm[] tvShows = new ComTopFilm[100];
        private ComTopFilm[] movies = new ComTopFilm[100];

        public TopOfApp()
        {
            InitializeComponent();

            LoadAllTop("TV series");
            LoadAllTop("Movie");            
        }

        private async void LoadAllTop(string gr)
        {
            Query query = db.Collection("Films")
                .OrderByDescending("rating")
                .OrderByDescending("numRate")
                .WhereEqualTo("genre", gr)
                .Limit(100);
            QuerySnapshot qSS = await query.GetSnapshotAsync();
            int i = 0;
            foreach (var docS in qSS)
            {
                DataFilm newF = docS.ConvertTo<DataFilm>();
                if (gr == "Movie") movies[i] = new ComTopFilm(newF, docS.Id, i+1);
                else tvShows[i] = new ComTopFilm(newF, docS.Id, i + 1);
                i++;
            }
        }

        private void btn100Movie_Click(object sender, RoutedEventArgs e)
        {
            panelTop.Children.Clear();
            foreach(var item in movies)
            {
                panelTop.Children.Add(item);
            }
        }

        private void btn100TV_Click(object sender, RoutedEventArgs e)
        {
            panelTop.Children.Clear();
            foreach (var item in tvShows)
            {
                panelTop.Children.Add(item);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btn100Movie.IsChecked = true;
            foreach (var item in movies)
            {
                panelTop.Children.Add(item);
            }
        }
    }
}
