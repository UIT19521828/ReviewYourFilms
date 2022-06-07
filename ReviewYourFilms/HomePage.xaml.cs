using ReviewYourFilms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Google.Cloud.Firestore;
using ReviewYourFilms.Models;
using System.Windows.Media.Animation;
using ReviewYourFilms.Authentication;

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private FirestoreDb db;

        public HomePage()
        {
            InitializeComponent();
            db = AccountManager.Instance().LoadDB();

            LoadBanner();
            LoadTop10Mv();
            LoadTop10TV();           
        }
        private async void LoadBanner()
        {        
            Query query = db.Collection("Banners");
            QuerySnapshot qSS = await query.GetSnapshotAsync();
            foreach(var item in qSS)
            {
                DataBanner banner = item.ConvertTo<DataBanner>();
                DocumentReference filmRef = db.Collection("Films").Document(item.Id);
                DocumentSnapshot filmSS = await filmRef.GetSnapshotAsync();
                DataFilm film = filmSS.ConvertTo<DataFilm>();
                
                flipView.Items.Add(new ComBanner(banner, film, filmSS.Id));
            }
        }

        private async void LoadTop10Mv()
        {
            RowOfFilm rowt10 = new RowOfFilm("Top 10 Movies");
            stackRowF.Children.Add(rowt10);
            Query query = db.Collection("Films").OrderByDescending("rating")
                .OrderByDescending("numRate").WhereEqualTo("genre", "Movie")
                .Limit(10);
            QuerySnapshot ssflim = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot film in ssflim.Documents)
            {
                DataFilm dtFilm = film.ConvertTo<DataFilm>();
                rowt10.stackFilm.Children.Add(new ComFilm(dtFilm, film.Id));
            }           
        }
        private async void LoadTop10TV()
        {
            RowOfFilm rowt10 = new RowOfFilm("Top 10 TV Series");
            stackRowF.Children.Add(rowt10);
            Query query = db.Collection("Films").OrderByDescending("rating")
                .OrderByDescending("numRate").WhereEqualTo("genre", "TV series")
                .Limit(10);
            QuerySnapshot ssflim = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot film in ssflim.Documents)
            {
                DataFilm dtFilm = film.ConvertTo<DataFilm>();
                rowt10.stackFilm.Children.Add(new ComFilm(dtFilm, film.Id));
            }           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoopBanner();
        }
        private async void LoopBanner()
        {
            while (true)
            {
                await Task.Delay(new TimeSpan(0, 0, 7)).ContinueWith(o => { NextBanner(); });
            }
        }

        private void NextBanner()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (flipView.SelectedIndex == flipView.Items.Count - 1)
                    flipView.SelectedIndex = 0;
                else flipView.SelectedIndex++;
            });
        }
    }
}
