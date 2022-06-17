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
using Google.Cloud.Firestore;

namespace ReviewYourFilms.Components
{
    /// <summary>
    /// Interaction logic for ComFilmCrew.xaml
    /// </summary>
    public partial class ComFilmCrew : UserControl
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private FirestoreDb db = AccountManager.Instance().LoadDB();
        private DataFirestore firestore = DataFirestore.Instance();
        public string pID { get; set; }
        public DataPeople data;
        public bool isDir;
        private SearchPage page;
        public ComFilmCrew(DataPeople data, string pID, bool isDir, SearchPage page)
        {
            InitializeComponent();
            this.data = data;
            this.pID = pID;
            this.isDir = isDir;
            this.page = page;
            LoadData();
        }
        private void LoadData()
        {
            txtName.Text = data.name;
            imgCrew.ImageSource = data.GetImage();
            if (!isDir) eFill.Fill = BaseColor.lowHas;
        }

        private async void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.NavHost.Content = page;
            page.panelQuery.Children.Clear();
            Query filmQ = null;
            if (isDir)
            {
                page.lbPath.Content = "Film titles from director: '" + data.name + "' ";
                filmQ = db.Collection("Films").WhereEqualTo("director", data.name);
            }
            else
            {
                page.lbPath.Content = "Film titles from actor: '" + data.name + "' ";
                filmQ = db.Collection("Films").WhereArrayContains("actor", pID);
            }
            QuerySnapshot filmSS = await filmQ.GetSnapshotAsync();
            foreach (var item in filmSS)
            {
                firestore.AddFirestore(item.ConvertTo<DataFilm>(), item.Id);
                page.panelQuery.Children.Add(
                        new ComFilm(firestore.GetFirestore(item.Id), item.Id));

            }
        }
    }
}
