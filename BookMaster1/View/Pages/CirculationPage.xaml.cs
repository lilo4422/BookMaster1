using BookMaster1.Model;
using BookMaster1.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookMaster1.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CirculationPage.xaml
    /// </summary>
    public partial class CirculationPage : Page
    {
        Customer customer = new Customer();
        Book book = new Book();
        List<Book> books = App.context.Book.ToList();
        List<Circulation> circulationList = App.context.Circulation.ToList();
        public CirculationPage()
        {
            InitializeComponent();
            IssueReturnBookGrid.Visibility = Visibility.Collapsed;
            EditCirculationBTN.Visibility = Visibility.Collapsed;
            CurrentIssueLV.ItemsSource = circulationList;
            HistoryLV.ItemsSource = circulationList;
        }

        private void EditCirculationBTN_Click(object sender, RoutedEventArgs e)
        {
            if (customer != null)
            {
                AddEditCustomer w = new AddEditCustomer(customer);
                w.Show();
            }
            else
            {
                MessageBox.Show("Сначала найдите пользователя!");
            }
        }

        private void RenewBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IssueBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CirculationBTN_Click(object sender, RoutedEventArgs e)
        {
            customer = App.context.Customer.FirstOrDefault(customer => customer.Id == CustomerIdTB.Text);
            if (customer != null)
            {
                IssueReturnBookGrid.Visibility = Visibility.Visible;
                EditCirculationBTN.Visibility = Visibility.Visible;
                SearchCustomerGrid.DataContext = customer;

                CurrentIssueLV.ItemsSource = App.context.Circulation.Where(circulation => circulation.CustomerId == customer.Id).ToList();

                HistoryLV.ItemsSource = App.context.Circulation.Where(circulation => circulation.DateOfReturn != null && circulation.CustomerId == customer.Id).ToList();
            }
        }
    }
}
