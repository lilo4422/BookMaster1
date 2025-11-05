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
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        List<Employee> employees = App.context.Employee.ToList();
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (employees.FirstOrDefault(em => em.Login == LoginTB.Text && em.Password == PasswordPB.Password) != null)
            {
                App.currentEmployee = employees.FirstOrDefault(em => em.Login == LoginTB.Text && em.Password == PasswordPB.Password);
                MessageBox.Show($"Добро пожаловать, {App.currentEmployee.Login}!");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show($"Неправильный логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
