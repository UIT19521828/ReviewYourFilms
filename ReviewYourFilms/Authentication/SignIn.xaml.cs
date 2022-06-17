using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReviewYourFilms.Authentication
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        AuthWindow authW = Application.Current.Windows[0] as AuthWindow;

        public SignIn()
        {
            InitializeComponent();
            txtEmail.Focus();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            gridMain.IsEnabled = false;
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("Input your information!");
            }
            else
            {
                if (await AccountManager.Instance().SignIn(txtEmail.Text, txtPass.Password))
                {
                    MessageBox.Show("Sign in success!", "Sign in");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();   
                    authW.Hide();
                }
            }
            gridMain.IsEnabled = true;
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            authW.frameAuth.Content = new SignUp();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
