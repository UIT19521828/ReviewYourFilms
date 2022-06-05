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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibVLCSharp.Shared;
using Google.Cloud.Firestore;
using ReviewYourFilms.Components;
using System.Windows.Media;

namespace ReviewYourFilms
{   
    public partial class DetailFilm : Page
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private LibVLC lib;
        private LibVLCSharp.Shared.MediaPlayer mediaPlayer;
        private DataFilm film;
        private string fid;

        public DetailFilm(DataFilm film, string fid)
        {
            InitializeComponent();
            this.film = film;
            this.fid = fid;           
            lib = new LibVLC();
            mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(lib);
            trailerPlayer.MediaPlayer = mediaPlayer;

            LoadDetailFilm();
            LoadTopReview();
        }
        private async void LoadDetailFilm()
        {
            float x = 0;
            if (film.numRate != 0) x = film.totalPoint / film.numRate;
            x = (float)Math.Round(x, 2);

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
            lbAvgRate.Content = x + "/10";

            imgPoster.ImageSource = film.GetImage();                     
            mediaPlayer.Play(new Media(lib, new Uri(film.trailer)));

            Query myR = main.db.Collection("Reviews").WhereEqualTo("user", Client.uid)
                    .WhereEqualTo("film", fid);
            QuerySnapshot mySS = await myR.GetSnapshotAsync();
            if(mySS.Count>0)
            {
                DataReview dataReview = mySS[0].ConvertTo<DataReview>();
                lbMyRate.Content = dataReview.score;
            }

            foreach(var item in film.category)
            {
                CreateButtonGenre(item);
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
                DataReview dataReview = rvSS[0].ConvertTo<DataReview>();
                ComReview topRv = new ComReview(dataReview, rvSS[0].Id);
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

            border.Child = btnGenre;
            panelButtonG.Children.Add(border);
        }
        private void NavBack_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            main.NavHost.GoBack();          
        }

        private void OpenReview_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            main.NavHost.Content = new ReviewPage(film, fid);
        }
    }
}
