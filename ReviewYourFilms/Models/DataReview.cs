using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ReviewYourFilms
{
    [FirestoreData]
    public class DataReview : INotifyPropertyChanged
    {
        [FirestoreProperty]
        public string content { get; set; }
        [FirestoreProperty]
        public string film { get; set; }
        [FirestoreProperty]
        public int score { get; set; }
        [FirestoreProperty]
        public string title { get; set; }
        [FirestoreProperty]
        public string user { get; set; }
        [FirestoreProperty]
        public List<string> isLike { get; set; }
        [FirestoreProperty]
        public List<string> isDis { get; set; }
        [FirestoreProperty]
        public int countLike { get; set; }
        [FirestoreProperty]
        public int countDis { get; set; }

        private int isChanged = 0;

        public DataReview(string content, string film, int score, string title, string user, List<string> isLike, List<string> isDis, int countLike, int countDis)
        {
            this.content = content;
            this.film = film;
            this.score = score;
            this.title = title;
            this.user = user;
            this.isLike = isLike;
            this.isDis = isDis;
            this.countLike = countLike;
            this.countDis = countDis;
        }
        public DataReview() { }

        public void ChangeData(string content, string title, int score)
        {
            this.content = content;
            this.title = title;
            this.score = score;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int IsChanged
        {
            get { return isChanged; }
            set 
            { 
                isChanged = value;
                NotifyPropertyChanged(nameof(IsChanged));
            }
        }
    }
}
