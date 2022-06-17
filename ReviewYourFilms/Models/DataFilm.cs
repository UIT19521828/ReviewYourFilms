using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Google.Cloud.Firestore;

namespace ReviewYourFilms
{
    [FirestoreData]
    public class DataFilm : INotifyPropertyChanged
    {
        
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string descript { get; set; }
        [FirestoreProperty]
        public string poster { get; set; }
        [FirestoreProperty]
        public int totalPoint { get; set; }
        [FirestoreProperty]
        public int numRate { get; set; }
        [FirestoreProperty]
        public List<string> category { get; set; }
        [FirestoreProperty]
        public int year { get; set; }
        [FirestoreProperty]
        public string trailer { get; set; }
        [FirestoreProperty]
        public string genre { get; set; }
        [FirestoreProperty]
        public int time { get; set; }
        [FirestoreProperty]
        public int eps { get; set; }
        [FirestoreProperty]
        public string director { get; set; }
        [FirestoreProperty]
        public string country { get; set; }
        [FirestoreProperty]
        public string[] actor { get; set; }

        private BitmapImage bit = null;

        public BitmapImage GetImage()
        {
            if(bit == null)
            {
                bit = new BitmapImage(new Uri(poster));               
            }           
            return bit;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int TotalScore
        {
            get 
            {
                return totalPoint;
            }
            set
            {
                totalPoint = value;
                NotifyPropertyChanged(nameof(TotalScore));
            }
        }
    }
}
