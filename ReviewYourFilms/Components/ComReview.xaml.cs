using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Cloud.Firestore;

namespace ReviewYourFilms.Components
{
    /// <summary>
    /// Interaction logic for ConReview.xaml
    /// </summary>
    public partial class ComReview : UserControl
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private DataReview data;
        private FirestoreDb db = AccountManager.Instance().LoadDB();
        private string rID;
        private DataUser user;
        private DocumentReference reviewRef;
        private bool needTitle;
        private DataFilm film;

        public ComReview(DataReview data, string rID, bool need)
        {
            InitializeComponent();
            this.data = data;
            this.rID = rID;
            this.needTitle = need;

            data.PropertyChanged += (s, e) => DataChanged();
            reviewRef = db.Collection("Reviews").Document(rID);
            LoadReview();
        }

        private bool ReturnIslike()
        {
            return data.isLike.Contains(Client.uid);
        }
        private bool ReturnIsDis()
        {
            return data.isDis.Contains(Client.uid);
        }
        private void SetLike(bool kq) 
        { 
            if (kq)
            {
                btnLike.Foreground = BaseColor.blueBrush;
                data.countLike++;
                data.isLike.Add(Client.uid);
            }
            else
            {
                btnLike.Foreground = BaseColor.defaultBrush;
                data.countLike--;
                data.isLike.Remove(Client.uid);
            }
            txtLike.Text = data.countLike + "";
        }
        private void SetDis(bool kq)
        {
            if (kq)
            {
                btnDis.Foreground = BaseColor.lowHas;
                data.countDis++;
                data.isDis.Add(Client.uid);
            }
            else
            {
                btnDis.Foreground = BaseColor.defaultBrush;
                data.countDis--;
                data.isDis.Remove(Client.uid);
            }
            txtDis.Text = data.countDis + "";
        }

        private void DataChanged()
        {
            if (user.imageURL != "") imgReviewer.ImageSource = user.GetImage();
            txtTitle.Text = data.title;
            txtScore.Content = data.score;
            SetRtf(data.content);
            txtReviewer.Text = user.name;
            txtLike.Text = data.countLike + "";
            txtDis.Text = data.countDis + "";
            if (ReturnIslike()) btnLike.Foreground = BaseColor.blueBrush;
            if (ReturnIsDis()) btnDis.Foreground = BaseColor.lowHas;
        }

        private async void LoadReview()
        {
            DocumentReference userRef = db.Collection("Users").Document(data.user);
            DocumentSnapshot userSS = await userRef.GetSnapshotAsync();
            user = userSS.ConvertTo<DataUser>();

            if (needTitle)
            {
                column1.Width = new GridLength(0);
                DocumentReference filmRef = db.Collection("Films").Document(data.film);
                DocumentSnapshot filmSS = await filmRef.GetSnapshotAsync();
                film = filmSS.ConvertTo<DataFilm>();
                txtFilmTitle.Text = film.name;
                txtFilmTitle.Visibility = Visibility.Visible;
            }
            DataChanged();
        }

        private void btnDis_Click(object sender, RoutedEventArgs e)
        {
            if (!ReturnIsDis())
            {
                if (ReturnIslike())
                {
                    RemoveFromLike();
                }
                AddToDis();
            }
            else if (ReturnIsDis())
            {
                RemoveFromDis();
            }
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            if (!ReturnIslike())
            {
                if (ReturnIsDis())
                {
                    RemoveFromDis();
                }
                AddToLike();
            }
            else if (ReturnIslike())
            {
                RemoveFromLike();
            }
        }

        private async void RemoveFromLike()
        {
            Dictionary<string, object> delete = new Dictionary<string, object>
            {
                { "isLike", FieldValue.ArrayRemove(Client.uid)}
            };
            await reviewRef.UpdateAsync(delete);
            await reviewRef.UpdateAsync("countLike", FieldValue.Increment(-1));          
            SetLike(false);
        }
        private async void RemoveFromDis()
        {
            Dictionary<string, object> delete = new Dictionary<string, object>
            {
                { "isDis", FieldValue.ArrayRemove(Client.uid)}
            };
            await reviewRef.UpdateAsync(delete);
            await reviewRef.UpdateAsync("countDis", FieldValue.Increment(-1));           
            SetDis(false);
        }
        private async void AddToLike()
        {           
            await reviewRef.UpdateAsync("isLike", FieldValue.ArrayUnion(Client.uid));
            await reviewRef.UpdateAsync("countLike", FieldValue.Increment(1));            
            SetLike(true);
        }

        private async void AddToDis()
        {
            await reviewRef.UpdateAsync("isDis", FieldValue.ArrayUnion(Client.uid));
            await reviewRef.UpdateAsync("countDis", FieldValue.Increment(1));           
            SetDis(true);
        }

        private void txtFilmTitle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            main.NavHost.Content = new DetailFilm(film, data.film);
        }

        public void SetRtf(string document)
        {
            var documentBytes = Encoding.UTF8.GetBytes(document);
            using (var reader = new MemoryStream(documentBytes))
            {
                reader.Position = 0;
                rtbContent.SelectAll();
                rtbContent.Selection.Load(reader, DataFormats.Rtf);
            }
        }
        private void OpenReviewer()
        {
            ProfileUser profile = new ProfileUser(data.user, main);
            profile.Show();
        }
        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenReviewer();
        }

        private void txtReviewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenReviewer();
        }
    }
}
