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
            if (string.IsNullOrEmpty(txtNickname.Text) ||
                string.IsNullOrEmpty(txtPass.Password) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Xin điền thông tin đăng nhập!");
            }
            else
            {
                if (txtPass.Password != txtRePass.Password)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp");
                }
                else
                {

                    if (await AccountManager.Instance().SignUp(txtEmail.Text, txtPass.Password, txtNickname.Text))
                    {
                        MessageBox.Show("Tạo tài khoản thành công!");
                        authW.frameAuth.GoBack();
                    }
                    else
                    {
                        MessageBox.Show("Không đăng ký được!!!");
                    }
                }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            authW.frameAuth.GoBack();
        }
    }
}
