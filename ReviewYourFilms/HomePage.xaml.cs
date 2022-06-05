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

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private FirestoreDb db;
        DataFilm dataFilm;
        string fID;
        public HomePage()
        {
            InitializeComponent();
            db = AccountManager.Instance().LoadDB();
            LoadTop10();
            LoadBanner();
        }
        private async void LoadBanner()
        {
            /*Query query = db.Collection("Banners");
            QuerySnapshot qSS = await query.GetSnapshotAsync();
            DataBanner bnr = qSS[0].ConvertTo<DataBanner>();
            imgBanner.ImageSource = bnr.GetImage();
            DocumentReference filmRef = db.Collection("Films").Document(qSS[0].Id);
            DocumentSnapshot filmSS = await filmRef.GetSnapshotAsync();
            dataFilm = filmSS.ConvertTo<DataFilm>();
            fID = filmSS.Id;*/
        }

        private async void LoadTop10()
        {
            RowOfFilm rowt10 = new RowOfFilm("Top 10");
            Query query = db.Collection("Films").OrderByDescending("rating")
                .OrderByDescending("numRate")
                .Limit(20);
            QuerySnapshot ssflim = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot film in ssflim.Documents)
            {
                DataFilm dtFilm = film.ConvertTo<DataFilm>();
                rowt10.stackFilm.Children.Add(new ConFilm(dtFilm, film.Id));
            }
            stackRowF.Children.Add(rowt10);
        }

        private void txtBanner_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(dataFilm, fID);
        }
    }
}
