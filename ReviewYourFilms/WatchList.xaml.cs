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
    /// Interaction logic for WatchList.xaml
    /// </summary>
    public partial class WatchList : Page
    {
        private FirestoreDb db = AccountManager.Instance().LoadDB();
        public WatchList()
        {
            InitializeComponent();
            LoadWL();
        }

        private async void LoadWL()
        {
            foreach(var item in Client.watchlist)
            {
                DocumentReference wlRef = db.Collection("Films").Document(item);
                DocumentSnapshot wlSS = await wlRef.GetSnapshotAsync();
                DataFilm dataFilm = wlSS.ConvertTo<DataFilm>();
                panelWL.Children.Add(new ComListFilm(dataFilm, wlSS.Id));
            }
        }
    }
}
