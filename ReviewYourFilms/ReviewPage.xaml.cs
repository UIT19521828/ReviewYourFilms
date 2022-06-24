using Google.Cloud.Firestore;
using ReviewYourFilms.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        private DataFirestore firestore = DataFirestore.Instance();

        private FirestoreDb db = AccountManager.Instance().LoadDB();
        private string fID;
        private int maxPage;
        private int nowPage;
        private bool hasReview = false;
        private DataFilm data;
        private DataReview tempRv = null;
        private DocumentReference reviewRef;

        public ReviewPage(DataFilm data, string fID)
        {
            InitializeComponent();
            this.data = data;
            this.fID = fID;
            nowPage = 1;
            txtNowP.Text = "1";
            LoadMyReview();
            LoadAllReview();
        }

        private async void LoadMyReview()
        {
            Query query = db.Collection("Reviews").WhereEqualTo("film", fID);
            QuerySnapshot qSS = await query.GetSnapshotAsync();
            maxPage = qSS.Count / 10 + 1;
            lbAllP.Content = "/ " + maxPage;

            imgPoster.ImageSource = data.GetImage();
            txtTitle.Text = data.name;
            txtYear.Content = "(" + data.year + ")";

            Query myR = db.Collection("Reviews").WhereEqualTo("user", Client.uid)
                    .WhereEqualTo("film", fID);
            QuerySnapshot mySS = await myR.GetSnapshotAsync();
            if (mySS.Count > 0)
            {
                hasReview = true;
                txtRatio.Visibility = Visibility.Visible;
                btnWrite.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
                firestore.AddReview(mySS[0].ConvertTo<DataReview>(), mySS[0].Id);
                tempRv = firestore.GetReview(mySS[0].Id);

                LoadTemp();

                reviewRef = db.Collection("Reviews").Document(mySS[0].Id);
            }
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
        public string GetRtf()
        {
            string kq;
            using (MemoryStream ms = new MemoryStream())
            {
                System.Windows.Documents.TextRange range = new System.Windows.Documents
                    .TextRange(rtbContent.Document.ContentStart, rtbContent.Document.ContentEnd);
                range.Save(ms, DataFormats.Rtf);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    kq = sr.ReadToEnd();
                }
            }
            return kq;
        }

        private async void LoadAllReview()
        {
            panelAllRv.Children.Clear();
            Query query = db.Collection("Reviews").WhereEqualTo("film", fID)
                            .OrderByDescending("countLike")
                            .OrderBy("countDis")
                            .Limit(10).Offset((nowPage - 1) * 10);
            QuerySnapshot qSS = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot docR in qSS)
            {
                firestore.AddReview(docR.ConvertTo<DataReview>(), docR.Id);
                ComReview view = new ComReview(
                    firestore.GetReview(docR.Id), docR.Id, false);
                panelAllRv.Children.Add(view);
            }
        }

        private void LoadTemp()
        {
            if (tempRv == null) return;

            ratingBox.Value = tempRv.score;
            txtRvTitle.Text = tempRv.title;
            SetRtf(tempRv.content);
            int pos = tempRv.countLike;
            int all = tempRv.countDis + pos;
            double percent = 0;
            if (all != 0)
            {
                percent = (double)pos / all * 100;
                percent = Math.Round(percent, 2);
            }
            txtRatio.Content = string.Format("({0}%){1} / {2} users like your review", percent, pos, all);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            main.NavHost.GoBack();
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            btnWrite.Visibility = Visibility.Collapsed;
            btnUpload.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            txtRvTitle.IsReadOnly = false;
            rtbContent.IsReadOnly = false;
            ratingBox.IsReadOnly = false;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Collapsed;
            btnUpload.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            txtRvTitle.IsReadOnly = false;
            rtbContent.IsReadOnly = false;
            ratingBox.IsReadOnly = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Do you want to cancel this review?!"
                   , "Cancel reviewing?", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                LoadTemp();
                btnCancel.Visibility = Visibility.Collapsed;
                btnUpload.Visibility = Visibility.Collapsed;
                if (hasReview) btnEdit.Visibility = Visibility.Visible;
                else btnWrite.Visibility = Visibility.Visible;
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Do you want to delete your review?!"
                ,"Delete Review", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                await reviewRef.DeleteAsync();
                btnDelete.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnWrite.Visibility = Visibility.Visible;
                ChangeAvegRating(-tempRv.score, -1);
                hasReview = false;
                reviewRef = null;
            }
        }

        private async void ChangeAvegRating(int total, int nRate)
        {
            DocumentReference filmRef = db.Collection("Films").Document(fID);
            await filmRef.UpdateAsync("totalPoint", FieldValue.Increment(total));
            if (nRate != 0)
                await filmRef.UpdateAsync("numRate", FieldValue.Increment(nRate));
            data.numRate += nRate;
            data.TotalScore += total;
        }

        private async void UpLoad_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Upload this review?"
                , "Upload Review", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                if (hasReview)
                {
                    Dictionary<string, object> update = new Dictionary<string, object>
                {
                    { "title", txtRvTitle.Text },
                    { "content", GetRtf() },
                    { "score",  ratingBox.Value}
                };
                    await reviewRef.UpdateAsync(update);
                    ChangeAvegRating(ratingBox.Value - tempRv.score, 0);
                }
                else
                {
                    List<string> array = new List<string>();
                    Dictionary<string, object> add = new Dictionary<string, object>
                {
                    { "content", GetRtf() },
                    { "countDis", 0 },
                    { "countLike", 0 },
                    { "film", fID },
                    { "isDis",  array },
                    { "isLike", array },
                    { "score" , ratingBox.Value},
                    { "title", txtRvTitle.Text },
                    { "user", Client.uid }
                };
                    tempRv = new DataReview(GetRtf(), fID, ratingBox.Value,
                                    txtRvTitle.Text, Client.uid, array, array, 0, 0);
                    reviewRef = await db.Collection("Reviews").AddAsync(add);                    
                    firestore.AddReview(tempRv, reviewRef.Id);
                    ChangeAvegRating(ratingBox.Value, 1);
                    hasReview = true;
                    btnDelete.Visibility = Visibility.Visible;
                }

                tempRv.ChangeData(GetRtf(), txtRvTitle.Text, ratingBox.Value);
                tempRv.IsChanged++;
                LoadTemp();
                btnCancel.Visibility = Visibility.Collapsed;
                btnUpload.Visibility = Visibility.Collapsed;
                txtRvTitle.IsReadOnly = true;
                rtbContent.IsReadOnly = true;
                ratingBox.IsReadOnly = true;
                btnEdit.Visibility = Visibility.Visible;

                MessageBox.Show("Upload review Success!");

                DocumentReference fRef = db.Collection("Films").Document(fID);

                double average = 0;
                if (data.numRate != 0) average = (double)data.totalPoint / data.numRate;
                average = Math.Round(average, 4);
                await fRef.UpdateAsync("rating", average);
                
                LoadAllReview();
            }          
        }

        private void MoveRight_Click(object sender, RoutedEventArgs e)
        {           
            if (nowPage < maxPage)
            {
                nowPage++;
                txtNowP.Text = (nowPage + 1) + "";
                LoadAllReview();
            }
        }

        private void MoveLeft_Click(object sender, RoutedEventArgs e)
        {
            if (nowPage > 1)
            {
                nowPage--;
                txtNowP.Text = (nowPage - 1) + "";
                LoadAllReview();
            }
        }

        private void txtNowP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtNowP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(int.Parse(txtNowP.Text) > maxPage || int.Parse(txtNowP.Text) <= 0)
                {
                    MessageBox.Show("Number of Page is wrong!", "Out of bound");
                    return;
                }
                else
                {
                    nowPage = int.Parse(txtNowP.Text);
                    LoadAllReview();
                    txtNowP.Text = nowPage +"";
                }
            }
        }

    }
}
