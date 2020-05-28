using Iceandfire.Models;
using Iceandfire.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Iceandfire.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : Page
    {
        public BooksPage()
        {
            this.InitializeComponent();
        }
        // Navigate to a book-s detail page
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;    
           Frame.Navigate(typeof(BookDetailsPage),book);
           
        }
        // Handles the searching event
        private void Search_Book_Click(Object sender, RoutedEventArgs e)
        {
            string name = TextBox.Text;
            var uri = "https://www.anapioficeandfire.com/" + "api/books?name=" + name;

            Frame.Navigate(typeof(BooksPage),uri);
        }


        //Load the next page. Call the DataContext ModelView instance's method.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BooksPageViewModel dc = (BooksPageViewModel)this.DataContext;
            string uri = dc.Service.GetNextLink();
            Frame.Navigate(typeof(BooksPage), uri);
        }
        //Load the first page. Call the DataContext ModelView instance's method.
        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BooksPage));
        }
        // 5 book / page
        private void hasteg5Click(Object sender, RoutedEventArgs e)
        {
            var uri = "https://www.anapioficeandfire.com/" + "api/books?pageSize=" + 5;
            Frame.Navigate(typeof(BooksPage), uri);

        }
        //10 book / page
        private void hasteg10Click(Object sender, RoutedEventArgs e)
        {
            var uri = "https://www.anapioficeandfire.com/" + "api/books?pageSize=" + 10;
            Frame.Navigate(typeof(BooksPage), uri);
        }
        // 15 book / page
        private void hasteg15Click(Object sender, RoutedEventArgs e)
        {
            var uri = "https://www.anapioficeandfire.com/" + "api/books?pageSize=" + 15;
            Frame.Navigate(typeof(BooksPage), uri);
        }


        //Load the last page. Call the DataContext ModelView instance's method.
        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            BooksPageViewModel dc = (BooksPageViewModel)this.DataContext;
            string uri = dc.Service.GetLastLink();
            Frame.Navigate(typeof(BooksPage),uri);
        }
        // Just for set the DataContext, the appropriate viewmodel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var url = (string)e.Parameter;
            if(url != null)
            DataContext = new BooksPageViewModel(url);
            else
            {
                DataContext = new BooksPageViewModel();
            }
            base.OnNavigatedTo(e);
        }

    }
}
