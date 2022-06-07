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
        public List<ComListFilm> list = new List<ComListFilm>();
        private int total = 0;
        public WatchList()
        {
            InitializeComponent();
            LoadWL();
        }

        public int Total
        {
            get { return total; }
            set
            {
                total = value;
                txtTotalItem.Text = total.ToString();
                LoadPanel();
            }
        }

        private async void LoadWL()
        {
            int cnt = 0;
            foreach(var item in Client.watchlist)
            {
                DocumentReference wlRef = db.Collection("Films").Document(item);
                DocumentSnapshot wlSS = await wlRef.GetSnapshotAsync();
                DataFilm dataFilm = wlSS.ConvertTo<DataFilm>();

                list.Add(new ComListFilm(dataFilm, wlSS.Id));
                cnt++;
            }
            Total = cnt;
        }
        private void LoadPanel()
        {
            panelWL.Children.Clear();
            foreach (var item in list)
            {
                panelWL.Children.Add(item);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int p = 0, c = 0;
            double x;
            foreach (var item in list)
            {
                if (item.score >= 0)
                {
                    c++;
                    p += item.score;
                }
            }
            if (c != 0)
            {
                x = p * 10 / c;
                x = Math.Round(x, 1);
                txtPercent.Text = x + "";
            }
        }
    }
}
