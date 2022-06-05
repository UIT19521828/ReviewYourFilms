using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Google.Cloud.Firestore;

namespace ReviewYourFilms
{
    [FirestoreData]
    public class DataFilm
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

        public BitmapImage GetImage()
        {
            if(!string.IsNullOrEmpty(poster))
                return new BitmapImage(new Uri(poster));
            return null;
        }
    }
}
