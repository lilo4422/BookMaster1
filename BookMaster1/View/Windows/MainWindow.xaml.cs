using BookMaster1.View.Pages;
using BookMaster1.View.Windows;
using System.Windows;

namespace BookMaster1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (App.currentEmployee == null)
            {
                LoginMI.Visibility = Visibility.Collapsed;
            }
            else
            {

                LogoutMI.Visibility = Visibility.Collapsed;
                LibraryMenu.Visibility = Visibility.Collapsed;
            }

        }

        private void LoginMI_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow authorizationWindow = new AutorizationWindow();
            if (authorizationWindow.ShowDialog() == true)
            {
                LoginMI.Visibility = Visibility.Collapsed;
                LogoutMI.Visibility = Visibility.Visible;
                LibraryMenu.Visibility = Visibility.Visible;
                MainFrame.Navigate(new BrowseCatalogPage());
            }
        }

        private void LogoutMI_Click(object sender, RoutedEventArgs e)
        {
            App.currentEmployee = null;
            LogoutMI.Visibility = Visibility.Collapsed;
            LibraryMenu.Visibility = Visibility.Collapsed;
            LoginMI.Visibility = Visibility.Visible;
            MainFrame.Navigate(null);
        }

        private void CloseMI_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ManageCustomersMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());
        }

        private void Circulation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportsMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseCatalogMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
