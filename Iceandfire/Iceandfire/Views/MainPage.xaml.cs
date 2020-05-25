using System;
using Windows.UI.Xaml.Controls;

namespace Iceandfire.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem.ToString();
            var pageType =
                label == "Books" ? typeof(BooksPage) : null;
            if(pageType != null && pageType != ContentFrame.CurrentSourcePageType)
            {
                ContentFrame.Navigate(pageType);
            }

        }
    }
}