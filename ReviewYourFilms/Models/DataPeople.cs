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
    public class DataPeople
    {
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string avatar { get; set; }
        public BitmapImage GetImage()
        {
            return new BitmapImage(new Uri(avatar));
        }
    }
}
