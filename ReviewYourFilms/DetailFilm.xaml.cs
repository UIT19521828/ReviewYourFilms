using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using LibVLCSharp.Shared;
using Google.Cloud.Firestore;
using ReviewYourFilms.Components;
using System.Windows.Media;

namespace ReviewYourFilms
{   
    public partial class DetailFilm : Page
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        private DataFirestore firestore = DataFirestore.Instance();

        private LibVLC lib;
        private LibVLCSharp.Shared.MediaPlayer mediaPlayer;
        private DataFilm film;
        private string fid;
        private DocumentReference userRef;
        public WatchList wl;

        public DetailFilm(DataFilm film, string fid)
        {
            InitializeComponent();
            this.film = film;
            this.fid = fid;
            userRef = main.db.Collection("Users").Document(Client.uid);
            wl = main.watchList;
            lib = new LibVLC();
            mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(lib);
            trailerPlayer.MediaPlayer = mediaPlayer;

            LoadDetailFilm();
            LoadTopReview();
            film.PropertyChanged += (s, e) => ChangeRate();
        }
        private void CreateButtonGenre(string item)
        {
            Border border = new Border();
            border.Width = Double.NaN;
            border.CornerRadius = new CornerRadius(15);
            border.Background = BaseColor.greyBrush;
            border.Margin = new Thickness(0, 0, 5, 0);

            Button btnGenre = new Button();
            btnGenre.BorderThickness = new Thickness(0);
            btnGenre.Cursor = Cursors.Hand;
            btnGenre.Foreground = Brushes.White;
            btnGenre.Background = Brushes.Transparent;
            btnGenre.Content = item;
            btnGenre.Click += BtnGenre_Click;

            border.Child = btnGenre;
            panelButtonG.Children.Add(border);
        }

        private void BtnGenre_Click(object sender, RoutedEventArgs e)
        {
            Button btnGenre = sender as Button;
            main.NavHost.Content = main.searchPage;
            main.searchPage.cbxGenre.Text = btnGenre.Content.ToString();
            main.searchPage.Dicovery_Click(sender, e);
        }

        private void ChangeRate()
        {
            float x = 0;
            if (film.numRate != 0) x = film.totalPoint / film.numRate;
            x = (float)Math.Round(x, 2);
            lbAvgRate.Content = x + "/10";
        }
        private async void LoadDetailFilm()
        {
            ChangeRate();
            txtDescript.Text = film.descript;
            txtDir.Text = film.director;
            string duration = film.time + "min";
            if (film.genre == "TV series")
            {
                duration += " (" + film.eps + "eps)";
            }
            txtGenre.Text = film.genre;
            txtTime.Text = duration;
            txtTitle.Text = film.name;
            txtYear.Text = film.year +"";
            txtCountry.Text = film.country;
            
            if (Client.watchlist.Contains(fid)) btnWL.Foreground = BaseColor.redBrush;

            imgPoster.ImageSource = film.GetImage();                     
            mediaPlayer.Play(new Media(lib, new Uri(film.trailer)));
            mediaPlayer.Pause();

            Query myR = main.db.Collection("Reviews").WhereEqualTo("user", Client.uid)
                    .WhereEqualTo("film", fid);
            QuerySnapshot mySS = await myR.GetSnapshotAsync();
            if(mySS.Count>0)
            {
                firestore.AddReview(mySS[0].ConvertTo<DataReview>(), mySS[0].Id);
                lbMyRate.Content = firestore.GetReview(mySS[0].Id).score + "/10";
            }

            foreach(var item in film.category)
            {
                CreateButtonGenre(item);
            }
            LoadActor();
        }

        private async void LoadActor()
        {
            foreach(var item in film.actor)
            {
                DocumentReference actorRef = main.db.Collection("Actors").Document(item);
                DocumentSnapshot actorSS = await actorRef.GetSnapshotAsync();
                DataPeople actor = actorSS.ConvertTo<DataPeople>();
                ComFilmCrew crew = new ComFilmCrew(actor, actorSS.Id, false, main.searchPage);
                panelActor.Children.Add(crew);
            }
        }

        private async void LoadTopReview()
        {
            Query rvRef = main.db.Collection("Reviews").WhereEqualTo("film", fid)
                            .OrderByDescending("countLike")
                            .OrderBy("countDis")
                            .Limit(1);
            QuerySnapshot rvSS = await rvRef.GetSnapshotAsync();
            if(rvSS.Count > 0)
            {
                lbTempReview.Visibility = Visibility.Collapsed;
                firestore.AddReview(rvSS[0].ConvertTo<DataReview>(), rvSS[0].Id);
                ComReview topRv = new ComReview(
                    firestore.GetReview(rvSS[0].Id), rvSS[0].Id, false);
                topRv.HorizontalAlignment = HorizontalAlignment.Left;

                panelReview.Children.Add(topRv);
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
                iconPlay.Kind = MaterialDesignThemes.Wpf.PackIconKind.PlayCircleOutline;
            }

            else
            {
                mediaPlayer.Play();
                iconPlay.Kind = MaterialDesignThemes.Wpf.PackIconKind.PauseCircleOutline;
            }
        }      
        private void NavBack_Click(object sender, RoutedEventArgs e)
        {            
            main.NavHost.GoBack();
        }
        private void OpenReview_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
                iconPlay.Kind = MaterialDesignThemes.Wpf.PackIconKind.PlayCircleOutline;
            }
            main.NavHost.Content = new ReviewPage(
                firestore.GetFirestore(fid), fid);
        }
        private async void WatchList_Click(object sender, RoutedEventArgs e)
        {
            DocumentSnapshot userSS = await userRef.GetSnapshotAsync();
            if (!Client.watchlist.Contains(fid))
            {
                await userRef.UpdateAsync("watchlist", FieldValue.ArrayUnion(fid));
                MessageBox.Show("Added to your watchlist!");
                Client.watchlist.Add(fid);
                btnWL.Foreground = BaseColor.redBrush;

                wl.list.Add(new ComListFilm(film, fid));
                wl.Total++;
            }

            else
            {
                await userRef.UpdateAsync("watchlist", FieldValue.ArrayRemove(fid));
                MessageBox.Show("Removed from watchlist");
                Client.watchlist.Remove(fid);
                btnWL.Foreground = BaseColor.defaultBrush;

                wl.list.RemoveAll(a => a.fID == fid);
                wl.Total--;
            }
            
        }
        protected virtual void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
                iconPlay.Kind = MaterialDesignThemes.Wpf.PackIconKind.PlayCircleOutline;
            }
        }
    }
}
