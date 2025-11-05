using BookMaster1.AppData;
using BookMaster1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookMaster1.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        List<BookAuthors> bookAuthors = App.context.BookAuthors.ToList();
        List<BookSubject> bookSubjects = App.context.BookSubject.ToList();
        List<Book> books = App.context.Book.ToList();
        List<Cover> covers = App.context.Cover.ToList();
        PaginationService<Cover> coverPagination;
        PaginationService<Book> bookPagination;

        public BrowseCatalogPage()
        {
            InitializeComponent();
            bookPagination = new PaginationService<Book>(books, 50);
            coverPagination = new PaginationService<Cover>(covers, 1);
            BookAuthorLV.ItemsSource = bookPagination.CurrentPageOfItems;
            BooksQuantityTBL.Text = books.Count.ToString();
            PageQuantityTBL.Text = bookPagination.TotalPages.ToString();
            bookPagination.UpdateNavigationButtons(NextPageBTN, PreviousPageBTN);
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLV.ItemsSource = books.Where(book => book.Title.ToLower().Contains(TitleTB.Text.ToLower()) &&
                                                           book.AuthorsList.ToLower().Contains(AuthorTB.Text.ToLower()) &&
                                                           book.Subjects.ToLower().Contains(SubjectTB.Text.ToLower()))
                                                           .ToList();
        }

        private void PreviousCoverBT_Click(object sender, RoutedEventArgs e)
        {
            CoverLB.ItemsSource = coverPagination.PreviousPage();
            coverPagination.UpdateNavigationButtons(NextCoverBTN, PreviousCoverBTN);
        }

        private void NextCoverBT_Click(object sender, RoutedEventArgs e)
        {
            CoverLB.ItemsSource = coverPagination.NextPage();
            coverPagination.UpdateNavigationButtons(NextCoverBTN, PreviousCoverBTN);
        }

        private void PreviousPageBTN_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLV.ItemsSource = bookPagination.PreviousPage();
            PageNumberTB.Text = bookPagination.CurrentPageNumber.ToString();
            bookPagination.UpdateNavigationButtons(NextPageBTN, PreviousPageBTN);
            BookAuthorLV.SelectedItem = null;
        }

        private void NextPageBTN_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLV.ItemsSource = bookPagination.NextPage();
            PageNumberTB.Text = bookPagination.CurrentPageNumber.ToString();
            bookPagination.UpdateNavigationButtons(NextPageBTN, PreviousPageBTN);
            BookAuthorLV.SelectedItem = null;
        }

        private void BookAuthorLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectBook = BookAuthorLV.SelectedItem as Book;
            if (selectBook != null)
            {

                List<Cover> covers = App.context.Cover.Where(c => c.BookId == selectBook.Id).ToList();
                List<Book> books = App.context.Book.ToList();
                BookDetailsGrid.DataContext = selectBook;
                coverPagination = new PaginationService<Cover>(covers, 1);
                CoverLB.ItemsSource = coverPagination.CurrentPageOfItems;
                coverPagination.UpdateNavigationButtons(NextCoverBTN, PreviousCoverBTN);
            }

        }

        private void NameBookTBL_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PageNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PageNumberTB.Text))
                {

                }
                else
                {
                    int pageNumbers = Convert.ToInt32(PageNumberTB.Text);
                    if (pageNumbers <=0 || pageNumbers > bookPagination.TotalPages)
                    {
                        MessageBox.Show("Такой страницы не существует");
                    }
                    else
                    {
                        BookAuthorLV.ItemsSource = bookPagination.SetCurrentPage(pageNumbers);
                        bookPagination.UpdateNavigationButtons(NextPageBTN, PreviousPageBTN);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    }
