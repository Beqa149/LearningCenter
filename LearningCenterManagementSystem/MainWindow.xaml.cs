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
using LearningCenterManagementSystem.User;

namespace LearningCenterManagementSystem
{ 
    public partial class MainWindow : Window
    {
        WPF.MDI.MdiContainer MainMdiContainer;

        public MainWindow(int userId)
        {
            InitializeComponent();
            MainMdiContainer = new WPF.MDI.MdiContainer();
            MainMdiContainer.Theme = WPF.MDI.ThemeType.Aero;
            UIPanel.Children.Add(MainMdiContainer);
        }   


        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("დარწმუნებული ხართ, რომ გსურთ პროგრამიდან გამოსვლა", "შეკითხვა", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void MenuAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainMdiContainer.Children.Clear();
                MainMdiContainer.Children.Add(new WPF.MDI.MdiChild
                {
                    Title = "ახალი მომხმარებლის დამატება",
                    Height = SystemParameters.PrimaryScreenHeight-70,
                    Width = SystemParameters.PrimaryScreenWidth - 70,
                    Style = null,
                    MinimizeBox = true,
                    Resizable = true,
                    ShowIcon = true,
                    Icon = new BitmapImage(new Uri("/IMAGES/AddNewUser.png", UriKind.Relative)),
                    Content = new AddUser()
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainMdiContainer.Children.Clear();
                MainMdiContainer.Children.Add(new WPF.MDI.MdiChild
                {
                    Title = "მომხმარებლის რედაქტირება",
                    Height = SystemParameters.PrimaryScreenHeight - 70,
                    Width = SystemParameters.PrimaryScreenWidth,
                    Style = null,
                    MinimizeBox = true,
                    Resizable = true,
                    ShowIcon = true,
                    Icon = new BitmapImage(new Uri("/IMAGES/EditUser.png", UriKind.Relative)),
                    Content = new EditUser()
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuBlockUnblockUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuUserList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
