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

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;    
           Frame.Navigate(typeof(BookDetailsPage),book);
           
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
        //Load the last page. Call the DataContext ModelView instance's method.
        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            BooksPageViewModel dc = (BooksPageViewModel)this.DataContext;
            string uri = dc.Service.GetLastLink();
            Frame.Navigate(typeof(BooksPage),uri);
        }
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
