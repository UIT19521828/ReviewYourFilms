using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Firebase.Auth;
using Firebase.Database;
using Google.Cloud.Firestore;

namespace ReviewYourFilms
{
    public class AccountManager
    {
        private static AccountManager instance;
        public static FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCHftKWgqCi8mzxcBrREek-qKoJVw9mxfs"));
        public FirebaseAuthLink link;
        public static bool isSignOut = false;
        public static FirestoreDb db = null;

        public static AccountManager Instance()
        {
            if (instance == null) instance = new AccountManager();
            return instance;
        }
        public FirestoreDb LoadDB()
        {
            if(db == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"filmreview.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("filmreview-de9c4");
            }           
            return db;
        }
        public async Task<bool> Refreshable()
        {
            try
            {
                var auth = new FirebaseAuth();
                auth.FirebaseToken = Client.token;
                auth.RefreshToken = Client.refreshToken;
                link = await authProvider.RefreshAuthAsync(auth);
                link = await link.GetFreshAuthAsync();
                link.FirebaseAuthRefreshed += AuthLink_FbAuthRefreshAsync;

                await link.RefreshUserDetails();
                if (string.IsNullOrEmpty(link.FirebaseToken)) return false;
                if (link.User == null) return false;
                isSignOut = false;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public async Task<bool> SignIn(string email, string pass)
        {
            db = LoadDB();
            try
            {

                link = await authProvider.SignInWithEmailAndPasswordAsync(email, pass);
                var client = new FirebaseClient(
                    "https://filmreview-de9c4-default-rtdb.asia-southeast1.firebasedatabase.app",
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(link.FirebaseToken),
                    }
                );
                /*if(link.User.IsEmailVerified == false)
                {
                    DialogResult rs = MessageBox.Show("Bạn chưa xác nhận email. Bạn có muốn gửi lại email xác nhận không", 
                        "Email is not verify", MessageBoxButtons.YesNo);
                    if(rs == DialogResult.Yes)
                    {
                        await authProvider.SendEmailVerificationAsync(link.FirebaseToken);
                    }
                    return false;
                }*/
                Client.email = link.User.Email;
                Client.uid = link.User.LocalId;
                Client.token = link.FirebaseToken;
                Client.refreshToken = link.RefreshToken;
                DocumentReference docRef = db.Collection("Users").Document(link.User.LocalId);
                DocumentSnapshot ss = await docRef.GetSnapshotAsync();
                if (ss.Exists)
                {
                    DataUser user = ss.ConvertTo<DataUser>();
                    Client.userName = user.name;
                    Client.uid = link.User.LocalId;
                    Client.imageURL = user.imageURL;
                    Client.bio = user.bio;
                    Client.email = user.email;
                    Client.watchlist = user.watchlist;
                    Client.followed = user.followed;
                }
                isSignOut = false;
                await link.RefreshUserDetails();
                link.FirebaseAuthRefreshed += AuthLink_FbAuthRefreshAsync;
                return true;
            }
            catch
            {
                MessageBox.Show("Fail to Sign In!");
                return false;
            }
        }
        public async Task<bool> SignUp(string email, string pass, string displayN)
        {
            db = LoadDB();
            try
            {
                link = await authProvider.CreateUserWithEmailAndPasswordAsync(email, pass);
                var client = new FirebaseClient(
                    "https://filmreview-de9c4-default-rtdb.asia-southeast1.firebasedatabase.app",
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(link.FirebaseToken),

                    });

                await authProvider.SendEmailVerificationAsync(link.FirebaseToken);
                string userid = link.User.LocalId;
                List<string> array = new List<string>();
                DocumentReference docRef = db.Collection("Users").Document(userid);
                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "name", displayN },
                    { "email", email },
                    { "bio", "" },
                    { "imageURL", "" },
                    { "watchlist", array },
                    { "followed", array }
                };
                await docRef.SetAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }    
        public bool SignOut()
        {
            try
            {
                Client.email = link.User.Email;
                Client.token = "";
                Client.refreshToken = "";
                isSignOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async void ChangeEmail(string email)
        {
            db = LoadDB();
            try
            {
                await authProvider.ChangeUserEmail(Client.token, email);
                Dictionary<string, object> updateEmail = new Dictionary<string, object>
                {
                    { "email", email },
                };              
                DocumentReference docRef = db.Collection("Users").Document(Client.uid);
                await docRef.UpdateAsync(updateEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private async void AuthLink_FbAuthRefreshAsync(object sender, FirebaseAuthEventArgs e)
        {
            Client.token = e.FirebaseAuth.FirebaseToken;
            Client.refreshToken = e.FirebaseAuth.RefreshToken;
            await link.RefreshUserDetails();
            isSignOut = !link.IsExpired();
        }
    }
}
