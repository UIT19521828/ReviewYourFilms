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
    public class DataUser
    {
        [FirestoreProperty]
        public string bio { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string imageURL { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public List<string> watchlist { get; set; }
        [FirestoreProperty]
        public List<string> followed { get; set; }

        public BitmapImage GetImage()
        {
            if (!string.IsNullOrEmpty(imageURL))
                return new BitmapImage(new Uri(imageURL));
            return null;
        }
    }
}
