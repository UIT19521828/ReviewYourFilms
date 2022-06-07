using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Cloud.Firestore;
using Microsoft.Win32;
using Firebase.Storage;
using ReviewYourFilms.Components;
using ReviewYourFilms.Authentication;

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Window
    {
        private DataUser _user;
        private bool isExpand = false;
        private DocumentReference clientRef;
        private FirestoreDb db = AccountManager.Instance().LoadDB();
        private string uid;
        private int miniH = 330;
        private List<ComReview> mReview = new List<ComReview>();
        private List<ComFilm> mFilm = new List<ComFilm>();
        private MainWindow main;
        public ProfileUser(string uid, MainWindow main)
        {
            InitializeComponent();
            this.uid = uid;
            this.Height = miniH;
            this.main = main;

            clientRef = db.Collection("Users").Document(Client.uid);
            GetUserData();
        }

        private async void GetUserData()
        {
            DocumentReference thisRef = db.Collection("Users").Document(uid);
            DocumentSnapshot thisSS = await thisRef.GetSnapshotAsync();
            _user = thisSS.ConvertTo<DataUser>();
            LoadUserUI();

            Query query = db.Collection("Reviews").WhereEqualTo("user", uid)
                            .OrderByDescending("score");
            QuerySnapshot snapshots = await query.GetSnapshotAsync();
            foreach (var reviewSS in snapshots)
            {
                DataReview rv = reviewSS.ConvertTo<DataReview>();
                ComReview viewReview = new ComReview(rv, reviewSS.Id, true);
                mReview.Add(viewReview);
            }

            foreach (string watchId in _user.watchlist)
            {
                DocumentReference docR = db.Collection("Films").Document(watchId);
                DocumentSnapshot filmSS = await docR.GetSnapshotAsync();
                DataFilm filmData = filmSS.ConvertTo<DataFilm>();
                ComFilm initF = new ComFilm(filmData, watchId);
                mFilm.Add(initF);
            }
            if(uid != Client.uid)
            {
                btnCamera.Visibility = Visibility.Collapsed;
                btnChange.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
            }
        }
        private void LoadUserUI()
        {
            txtUsername.Text = _user.name;
            txtEmail.Text = _user.email;
            if (_user.bio != "")
                SetRtf(_user.bio);
            if (_user.imageURL != "")
            {
                imgUser.ImageSource = _user.GetImage();
            }
        }

        private async void Avatar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png;*.jpg; *.jpeg; *.gif; *.bmp)|*.png;*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == true)
            {
                string filePath = open.FileName;               

                var newStream = File.Open(filePath, FileMode.Open);
                var task = new FirebaseStorage(
                    "filmreview-de9c4.appspot.com",
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(Client.token),
                        ThrowOnCancel = true
                    })
                    .Child("UserAvatars")
                    .Child(Client.uid + ".png")
                    .PutAsync(newStream);
                string url = await task;
                Dictionary<string, object> update = new Dictionary<string, object>
                {
                    { "imageURL", url }
                };
                await clientRef.UpdateAsync(update);
                Client.imageURL = url;
                _user.imageURL = url;

                BitmapImage bit = new BitmapImage(new Uri(open.FileName));
                imgUser.ImageSource = bit;
                main.imgClient.ImageSource = bit;              
            }
        }

        private void btnReview_Click(object sender, RoutedEventArgs e)
        {
            btnWL.Foreground = Brushes.White;
            btnWL.Background = BaseColor.greyBrush;
            btnReview.Foreground = BaseColor.greyBrush;
            btnReview.Background = Brushes.White;
            
            panelContent.Children.Clear();
            panelContent.Orientation = Orientation.Vertical;
            foreach (var item in mReview)
            {
                panelContent.Children.Add(item);
            }
        }

        private void btnWL_Click(object sender, RoutedEventArgs e)
        {
            btnReview.Foreground = Brushes.White;
            btnReview.Background = BaseColor.greyBrush;
            btnWL.Foreground = BaseColor.greyBrush;
            btnWL.Background = Brushes.White;

            panelContent.Children.Clear();
            panelContent.Orientation = Orientation.Horizontal;
            foreach (var item in mFilm)
            {
                panelContent.Children.Add(item);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult edit = MessageBox.Show("Edit user information?", "Edit", MessageBoxButton.YesNo);
            if (edit == MessageBoxResult.Yes)
            {
                txtUsername.IsReadOnly = false;
                rtbBio.IsReadOnly = false;
                btnEdit.Visibility = Visibility.Collapsed;
                btnUpLoad.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Visible;
            }
        }

        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult edit = MessageBox.Show("Upload user information?", "Upload", MessageBoxButton.YesNo);
            if (edit == MessageBoxResult.Yes)
            {
                Dictionary<string, object> update = new Dictionary<string, object>
                {
                    { "bio", GetRtf() },
                    { "name", txtUsername.Text }
                };
                await clientRef.UpdateAsync(update);
                _user.bio = GetRtf();
                _user.name = txtUsername.Text;

                txtUsername.IsReadOnly = true;
                rtbBio.IsReadOnly = true;
                btnEdit.Visibility = Visibility.Visible;
                btnUpLoad.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Collapsed;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult edit = MessageBox.Show("Cancel Edit Information", "Cancel", MessageBoxButton.YesNo);
            if (edit == MessageBoxResult.Yes)
            {
                txtUsername.IsReadOnly = true;
                rtbBio.IsReadOnly = true;
                btnEdit.Visibility = Visibility.Visible;
                btnUpLoad.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Collapsed;
                LoadUserUI();
            }         
        }

        private void ChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            ChangeUserEmail changeE = new ChangeUserEmail(txtEmail.Text);
            changeE.Show();
        }

        private void Expand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isExpand)
            {
                this.Height = miniH;
                btnExpand.Icon = FontAwesome.WPF.FontAwesomeIcon.CaretUp;
                isExpand = false;
            }
            else
            {
                this.Height = 820;
                isExpand = true;
                btnExpand.Icon = FontAwesome.WPF.FontAwesomeIcon.CaretDown;
            }
        }

        public void SetRtf(string document)
        {
            var documentBytes = Encoding.UTF8.GetBytes(document);
            using (var reader = new MemoryStream(documentBytes))
            {
                reader.Position = 0;
                rtbBio.SelectAll();
                rtbBio.Selection.Load(reader, DataFormats.Rtf);
            }
        }
        public string GetRtf()
        {
            string kq;
            using (MemoryStream ms = new MemoryStream())
            {
                System.Windows.Documents.TextRange range = new System.Windows.Documents
                    .TextRange(rtbBio.Document.ContentStart, rtbBio.Document.ContentEnd);
                range.Save(ms, DataFormats.Rtf);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    kq = sr.ReadToEnd();
                }
            }
            return kq;
        }

        private void Escape_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }
    }
}
