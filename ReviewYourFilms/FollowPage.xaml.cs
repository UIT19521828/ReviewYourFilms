using System;
using System.Collections.Generic;
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
using ReviewYourFilms.Components;

namespace ReviewYourFilms
{
    /// <summary>
    /// Interaction logic for FollowPage.xaml
    /// </summary>
    public partial class FollowPage : Page
    {
        private FirestoreDb db = AccountManager.Instance().LoadDB();

        public FollowPage()
        {
            InitializeComponent();
        }
        public async void LoadFollow()
        {
            panelFollowing.Children.Clear();
            foreach (var item in Client.followed)
            {
                DocumentReference flRef = db.Collection("Users").Document(item);
                DocumentSnapshot flSS = await flRef.GetSnapshotAsync();
                panelFollowing.Children.Add(new Follower(flSS.ConvertTo<DataUser>(), flSS.Id));
            }
        }
    }
}
