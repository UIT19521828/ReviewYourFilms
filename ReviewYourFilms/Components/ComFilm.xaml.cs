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
using System.ComponentModel;

namespace ReviewYourFilms.Components
{
    public partial class ComFilm : UserControl
    {
        MainWindow main  = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        private DataFirestore firestore = DataFirestore.Instance();

        private DataFilm data;
        private string fid;
        private BitmapImage bit;

        public ComFilm(DataFilm film, string fid)
        {
            InitializeComponent();  
            this.fid = fid;
            this.data = film;

            data.PropertyChanged += (s, e) => ChangeRate();
            LoadFilm();
        }

        private void ChangeRate()
        {
            int x = 0;
            if (data.numRate != 0) x = data.totalPoint * 10 / data.numRate;
            txtPercent.Text = x.ToString();
            
            if(x>=70)
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
        private void LoadFilm()
        {
            ChangeRate();
            txtTitle.Text = data.name;
            bit = data.GetImage();
            imgPoster.ImageSource = bit;
        }

        private void NewDetail_Click(object sender, RoutedEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(
                firestore.GetFirestore(fid), fid);
        }
    }
}
