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
using System.Collections.ObjectModel;
using Google.Cloud.Firestore;
using LiveCharts;
using LiveCharts.Defaults;

namespace ReviewYourFilms.Components
{
    /// <summary>
    /// Interaction logic for ComListFilm.xaml
    /// </summary>
    public partial class ComListFilm : UserControl
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        
        public string fID;
        public int score = -1;
        private DataFilm data;       
        private FirestoreDb db = AccountManager.Instance().LoadDB();       

        public ComListFilm(DataFilm data, string fID)
        {
            InitializeComponent();
            this.data = data;
            this.fID = fID;

            LoadClientRate();
            LoadWL_Film();            
        }

        private void LoadWL_Film()
        {
            int x = 0;
            if (data.numRate != 0) x = data.totalPoint / data.numRate * 10;

            txtPercent.Text = x.ToString();
            txtTitle.Text = data.name;
            string duration = data.time + "min";
            if (data.genre == "TV series")
            {
                duration += " (" + data.eps + "eps)";
            }
            txtTime.Text = duration;
            txtYear.Text = data.year + "";
            txtDescript.Text = data.descript;
            txtGenre.Text = data.genre;
            txtDir.Text = data.director;
            if (x < 70 && x > 40)
            {
                pieHas.Fill = BaseColor.midHas;
                pieNo.Fill = BaseColor.midNo;
            }
            if (x < 40)
            {
                pieHas.Fill = BaseColor.lowHas;
                pieNo.Fill = BaseColor.lowNo;
            }
            pieHas.Values = new ChartValues<ObservableValue> { new ObservableValue(x) };
            pieNo.Values = new ChartValues<ObservableValue> { new ObservableValue(100 - x) };
            imgPoster.ImageSource = data.GetImage();

            int i = 0;
            string genre = "";
            foreach(var item in data.category)
            {
                genre += item;
                i++;
                if (i == 2) break;
                genre += ",";
            }
            txtCate.Text = genre;
        }

        private async void LoadClientRate()
        {
            Query rvRef = db.Collection("Reviews")
                .WhereEqualTo("user", Client.uid).WhereEqualTo("film", fID);
            QuerySnapshot rvSS = await rvRef.GetSnapshotAsync();
            if (rvSS.Count > 0)
            {
                DataReview dataReview = rvSS[0].ConvertTo<DataReview>();
                score = dataReview.score;
                txtMyRate.Text = score + "";
                tempRate.Visibility = Visibility.Collapsed;
                myRate.Visibility = Visibility.Visible;
                if (score < 7 && score > 4) fillE.Fill = BaseColor.midHas;
                if (score < 4) fillE.Fill = BaseColor.lowHas;
            }
        }

        private void NewDetail_Click(object sender, RoutedEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(data, fID);
        }

        private async void RemoveWL_Click(object sender, RoutedEventArgs e)
        {
            main.watchList.panelWL.Children.Remove(this);
            DocumentReference userRef = main.db.Collection("Users").Document(Client.uid);
            await userRef.UpdateAsync("watchlist", FieldValue.ArrayRemove(fID));
            Client.watchlist.Remove(fID);
            main.watchList.Total--;
        }

        private void txtTitle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(data, fID);
        }
    }
}
