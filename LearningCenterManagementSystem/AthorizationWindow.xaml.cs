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

namespace LearningCenterManagementSystem
{
    /// <summary>
    /// Interaction logic for AthorizationWindow.xaml
    /// </summary>
    public partial class AthorizationWindow : Window
    {
        public AthorizationWindow()
        {
            InitializeComponent();
        }

        private void but_SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string user_name = txtBox_UserName.Text;
                string password = txtBox_Password.Password;

                //MessageBox.Show($"User Name: {user_name} Password: {password}");

                int userId = 0;

                #region წარმატებული ავტორიზაციის შემთხვევაში

                MainWindow m = new MainWindow(userId);
                m.Show();
                Close();

                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
