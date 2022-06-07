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
using System.Windows.Shapes;

namespace ReviewYourFilms.Authentication
{
    /// <summary>
    /// Interaction logic for ChangeUserEmail.xaml
    /// </summary>
    public partial class ChangeUserEmail : Window
    {
        string oldE;
        public ChangeUserEmail(string oldE)
        {
            InitializeComponent();
            this.oldE = oldE;
            Topmost = true;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewEmail.Text != oldE)
            {
                MessageBoxResult edit = MessageBox.Show("This will be your new Email?", "Change Email");
                if (edit == MessageBoxResult.OK)
                {
                    AccountManager.Instance().ChangeEmail(txtNewEmail.Text);
                }
                    
            }
                
            else MessageBox.Show("Input new Email!");
        }
    }
}
