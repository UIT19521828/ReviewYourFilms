using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewYourFilms
{
    public class DataFirestore
    {
        private static DataFirestore instance;

        private Dictionary<string, DataFilm> data = new Dictionary<string, DataFilm>();
        private Dictionary<string, DataReview> reviewArr = new Dictionary<string, DataReview>();
        public static DataFirestore Instance()
        {
            if(instance == null) instance = new DataFirestore();
            return instance;
        }

        public void AddFirestore(DataFilm film, string fID)
        {
            if (!data.ContainsKey(fID))
            {
                data.Add(fID, film);
            }
        }

        public DataFilm GetFirestore(string fID)
        {
            return data[fID];
        }

        public bool IsFetch(string id)
        {
            return (data.ContainsKey(id));
        }

        public void AddReview(DataReview rv, string rID)
        {
            if (!reviewArr.ContainsKey(rID))
            {
                reviewArr.Add(rID, rv);
            }
        }

        public DataReview GetReview(string rID)
        {
            return reviewArr[rID];
        }

        public bool IsReviewFetch(string rID)
        {
            return (reviewArr.ContainsKey(rID));
        }

    }
}
