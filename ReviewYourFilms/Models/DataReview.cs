using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ReviewYourFilms
{
    [FirestoreData]
    public class DataReview
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
    }
}
