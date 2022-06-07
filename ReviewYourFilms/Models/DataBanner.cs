using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Google.Cloud.Firestore;

namespace ReviewYourFilms.Models
{
    [FirestoreData]
    public class DataBanner
    {
        [FirestoreProperty]
        public string bannerURL { get; set; }

        public BitmapImage GetImage()
        {
            return new BitmapImage(new Uri(bannerURL));
        }
    }
}
