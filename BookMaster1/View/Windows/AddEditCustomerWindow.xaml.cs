using BookMaster1.Model;
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

namespace BookMaster1.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        public AddEditCustomer()
        {
            InitializeComponent();

            string lastIndex = App.context.Customer.Max(customer => customer.Id);
            int lastIndexNumber = Convert.ToInt32(lastIndex.Remove(0, 1));
            IdTB.Text = $"C{++lastIndexNumber}";
        }
        public AddEditCustomer(Customer selectedCustomer)
        {
            InitializeComponent();

            DataContext = selectedCustomer;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
