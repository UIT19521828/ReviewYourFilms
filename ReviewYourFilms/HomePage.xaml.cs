using ReviewYourFilms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Google.Cloud.Firestore;


namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private FirestoreDb db;
        public HomePage()
        {
            InitializeComponent();
            db = AccountManager.Instance().LoadDB();
            LoadTop10();
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

    }
}
