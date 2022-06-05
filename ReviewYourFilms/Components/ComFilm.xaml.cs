using LiveCharts;
using LiveCharts.Wpf;
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

namespace ReviewYourFilms
{
    public partial class ConFilm : UserControl
    {
        MainWindow main  = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private DataFilm data;
        private string fid;

        public ConFilm(DataFilm film, string fid)
        {
            InitializeComponent();  
            this.fid = fid;
            this.data = film;
            LoadFilm();
        }

        private void LoadFilm()
        {
            int x = 0;
            if (data.numRate != 0) x = data.totalPoint / data.numRate * 10;

            txtPercent.Text = x.ToString();
            txtTitle.Text = data.name;
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
            pieHas.Values = new ChartValues<ObservableValue> { new ObservableValue(x)};
            pieNo.Values = new ChartValues<ObservableValue> { new ObservableValue(100-x) };
            imgPoster.ImageSource = data.GetImage();
        }

        private void NewDetail_Click(object sender, RoutedEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(data, fid);
        }
    }
}
