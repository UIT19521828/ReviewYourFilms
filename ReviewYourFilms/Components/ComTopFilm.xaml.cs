using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReviewYourFilms.Components
{
    /// <summary>
    /// Interaction logic for ComTopFilm.xaml
    /// </summary>
    public partial class ComTopFilm : UserControl
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private DataFilm data;
        private string fID;
        private int index;

        public ComTopFilm(DataFilm data, string fID, int index)
        {
            InitializeComponent();
            this.data = data;
            this.fID = fID;
            this.index = index;
            data.PropertyChanged += (s, e) => ChangeRate();
            LoadTopFilm();
        }
        private void ChangeRate()
        {
            int x = 0;
            if (data.numRate != 0) x = data.totalPoint * 10 / data.numRate;
            txtPercent.Text = x.ToString();

            if (x >= 70)
            {
                pieHas.Fill = BaseColor.highHas;
                pieNo.Fill = BaseColor.highNo;
            }
            if (x < 70 && x >= 40)
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
        }

        private void LoadTopFilm()
        {
            ChangeRate();
            txtTitle.Text = index + ". " + data.name;
            string duration = data.time + "min";
            if (data.genre == "TV series")
            {
                duration += " (" + data.eps + "eps)";
            }
            txtTime.Text = duration;
            txtGenre.Text = data.genre;
            txtYear.Text = data.year + "";
            txtDir.Text = data.director;
            if(data.poster!="") imgPoster.Source = data.GetImage();

            int i = 0;
            string genre = "";
            foreach (var item in data.category)
            {                
                genre += item;
                i++;
                if (i == 2) break;
                genre += ",";                
            }
            txtCate.Text = genre;
        }

        private void NewDetail_Click(object sender, RoutedEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(data, fID);
        }

        private void Title_MouseClick(object sender, MouseButtonEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(data, fID);
        }
    }
}
