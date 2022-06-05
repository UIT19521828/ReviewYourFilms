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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        AuthWindow authW = Application.Current.Windows[0] as AuthWindow;

        public SignUp()
        {
            InitializeComponent();
        }

        private async void SignUp_Click(object sender, RoutedEventArgs e)
        {
            gridSU.IsEnabled = false;
            if (string.IsNullOrEmpty(txtNickname.Text) ||
                string.IsNullOrEmpty(txtPass.Password) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Input your information!");
            }
            else
            {
                if (txtPass.Password != txtRePass.Password)
                {
                    MessageBox.Show("Repeat password is not correct!");
                }
                else
                {

                    if (await AccountManager.Instance().SignUp(txtEmail.Text, txtPass.Password, txtNickname.Text))
                    {
                        MessageBox.Show("Success Create Account!");
                        authW.frameAuth.GoBack();
                    }
                    else
                    {
                        MessageBox.Show("Can't Sign up!!!");
                    }
                }
            }
            gridSU.IsEnabled = true;
        }


        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            authW.frameAuth.GoBack();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtNickname.Focus();
            }
        }

        private void txtNickname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtRePass.Focus();
            }
        }

        private void txtRePass_KeyDown(object sender, KeyEventArgs e)
        {
            SignUp_Click(sender, e);
        }
    }
}
