using BookMaster1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace BookMaster1.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CirculationPage.xaml
    /// </summary>
    public partial class CirculationPage : Page
    {
        Customer customer = new Customer();
        Book book = new Book();
        List<Circulation> circulationList = App.context.Circulation.ToList();
        public CirculationPage()
        {
            InitializeComponent();
            CurrentIssueLV.ItemsSource = circulationList;
            HistoryLV.ItemsSource = circulationList;
        }

        private void EditCirculationBTN_Click(object sender, RoutedEventArgs e)
        {

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
            customer=App.context.Customer.FirstOrDefault(customer=> customer.Id==CustomerIdTB.Text);
            if (customer!=null) 
            {
                SearchCustomerGrid.DataContext = customer;
            }
        }
    }
}
