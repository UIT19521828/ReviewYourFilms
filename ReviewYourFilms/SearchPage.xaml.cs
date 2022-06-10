using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Google.Cloud.Firestore;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReviewYourFilms.Components;

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private FirestoreDb db = AccountManager.Instance().LoadDB();
        private DataFirestore firestore = DataFirestore.Instance();

        public string _search { get; set; }
        public SearchPage()
        {
            DataContext = this;
            InitializeComponent();           
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            panelQuery.Children.Clear();
            if (!string.IsNullOrEmpty(_search))
            {
                Query searchQ = null;
                if (cbxBy.SelectedIndex == 0)
                {
                    searchQ = db.Collection("Films").WhereGreaterThanOrEqualTo("name", _search)
                        .WhereLessThanOrEqualTo("name", _search + "\uf8ff");
                }
                if(cbxBy.SelectedIndex == 1)
                {
                    lbPath.Content = "Directors from '" + _search + "...' ";
                    searchQ = db.Collection("Directors").WhereGreaterThanOrEqualTo("name", _search)
                        .WhereLessThanOrEqualTo("name", _search + "\uf8ff");
                }
                if (cbxBy.SelectedIndex == 2)
                {
                    lbPath.Content = "Actors from '" + _search + "...' ";
                    searchQ = db.Collection("Actors").WhereGreaterThanOrEqualTo("name", _search)
                        .WhereLessThanOrEqualTo("name", _search + "\uf8ff");
                }
                QuerySnapshot searchSS = await searchQ.GetSnapshotAsync();
                foreach(var item in searchSS)
                {
                    if (cbxBy.SelectedIndex == 0)
                    {
                        lbPath.Content = "Film titles from '" + _search +"...' ";
                        firestore.AddFirestore(item.ConvertTo<DataFilm>(), item.Id);
                        panelQuery.Children.Add(
                            new ComFilm(firestore.GetFirestore(item.Id), item.Id));
                    }
                    else
                    {
                        bool isDir = false;
                        if (cbxBy.SelectedIndex == 1) isDir = true;
                        ComFilmCrew people = new ComFilmCrew(item.ConvertTo<DataPeople>(), 
                            item.Id, isDir, this);
                        panelQuery.Children.Add(people);
                    }   
                }
            }
        }

        private async void Dicovery_Click(object sender, RoutedEventArgs e)
        {
            panelQuery.Children.Clear();
            string selectedCbx = ((ComboBoxItem)cbxGenre.SelectedItem).Content.ToString();
            lbPath.Content = "Discovery from Genre: '" + selectedCbx + "' ";

            Query genreQ = db.Collection("Films")
                .WhereArrayContains("category", selectedCbx);
            QuerySnapshot genreSS = await genreQ.GetSnapshotAsync();
            foreach (var item in genreSS)
            {
                firestore.AddFirestore(item.ConvertTo<DataFilm>(), item.Id);
                panelQuery.Children.Add(
                    new ComFilm(firestore.GetFirestore(item.Id), item.Id));
            }
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search_Click(sender, e);
            }
        }
    }
}
