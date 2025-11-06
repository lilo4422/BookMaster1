using BookMaster1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            lastIndexNumber++;
            IdTB.Text = $"C{lastIndexNumber}";

            EditBTN.Visibility = Visibility.Collapsed;
            SaveBTN.Visibility = Visibility.Visible;
            CitiesCmb.ItemsSource = App.context.City.ToList();
        }
        public AddEditCustomer(Customer selectedCustomer)
        {
            InitializeComponent();

            EditBTN.Visibility = Visibility.Visible;
            SaveBTN.Visibility = Visibility.Collapsed;
   
            DataContext = selectedCustomer;

            CitiesCmb.ItemsSource = App.context.City.ToList();
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FNameTB.Text) ||
                string.IsNullOrEmpty(LNameTB.Text)||
                string.IsNullOrEmpty(AddressTB.Text) ||
                string.IsNullOrEmpty(PhoneTB.Text) ||
                string.IsNullOrEmpty(ZipTB.Text) ||
                string.IsNullOrEmpty(EmailTB.Text) ||
                CitiesCmb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Customer newCustomer = new Customer()
                {
                    Id = IdTB.Text,
                    Fname = FNameTB.Text,
                    Lname = LNameTB.Text,
                    MiddleName = MNameTB.Text,
                    Zip = ZipTB.Text,
                    Addres = AddressTB.Text,
                    PhoneNubmer = PhoneTB.Text,
                    Email = EmailTB.Text,
                    CityId = Convert.ToInt32(CitiesCmb.SelectedValue)
                };
                App.context.Customer.Add(newCustomer);
                App.context.SaveChanges();
                MessageBox.Show("Сотрудник успешно создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            
            App.context.SaveChanges();

            MessageBox.Show("Изменения успешно сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
