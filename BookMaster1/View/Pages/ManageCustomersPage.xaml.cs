using BookMaster1.Model;
using BookMaster1.View.Windows;
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

namespace BookMaster1.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        List<Customer> customers = App.context.Customer.ToList();
        public ManageCustomersPage()
        {
            InitializeComponent();
          CutomerLV.ItemsSource = customers;
        }

        private void AddCustomerBTN_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer w = new AddEditCustomer();
            w.Show();
        }

        private void EditCustomerBTN_Click(object sender, RoutedEventArgs e)
        {
            if (CutomerLV.SelectedItem != null)
            {
                AddEditCustomer w = new AddEditCustomer(CutomerLV.SelectedItem as Customer);
                w.Show();
            }
        }

        private void SearchCustomerBTN_Click(object sender, RoutedEventArgs e)
        {
            CutomerLV.ItemsSource=customers.Where(customer=>customer.Id.ToLower().Contains(CustomerIdTB.Text.ToLower())&&
                                                customer.FullName.Contains(CustomerNameTB.Text.ToLower())).ToList();
        }
    }
}
