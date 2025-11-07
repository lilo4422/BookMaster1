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
    /// Логика взаимодействия для AuthorsBioWindow.xaml
    /// </summary>
    public partial class AuthorsBioWindow : Window
    {
        List<Author> authors=App.context.Author.ToList();
        public AuthorsBioWindow()
        {
            InitializeComponent();
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
