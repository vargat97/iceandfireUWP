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
    public sealed partial class HousesPage : Page
    {
        public HousesPage()
        {
            this.InitializeComponent();
        }
        // load the clicked house details page
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var house = (House)e.ClickedItem;
            Frame.Navigate(typeof(HouseDetailsPage), house);
        }
        //handles the search event
        private void Search_House_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBox.Text;
            var uri = "https://www.anapioficeandfire.com/" + "api/houses?name=" + name;

            Frame.Navigate(typeof(HousesPage), uri);
        }

        //Load the next page. Call the DataContext ModelView instance's method.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HousesPageViewModel dc = (HousesPageViewModel)this.DataContext;
            string uri = dc.Service.GetNextLink();
            Frame.Navigate(typeof(HousesPage), uri);
        }
        //Load the first page. Call the DataContext ModelView instance's method.
        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HousesPage));
        }
        //Load the last page. Call the DataContext ModelView instance's method.
        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            HousesPageViewModel dc = (HousesPageViewModel)this.DataContext;
            string uri = dc.Service.GetLastLink();
            Frame.Navigate(typeof(HousesPage), uri);
        }
        //just for set the appropriate viewmodel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var url = (string)e.Parameter;
            if (url != null)
                DataContext = new HousesPageViewModel(url);
            else
            {
                DataContext = new HousesPageViewModel();
            }
            base.OnNavigatedTo(e);
        }
        // 5 houses / page
        private void hasteg5Click(Object sender, RoutedEventArgs e)
        {
            var uri = "https://www.anapioficeandfire.com/" + "api/houses?pageSize=" + 5;
            Frame.Navigate(typeof(HousesPage), uri);

        }
        // 10 houses / page
        private void hasteg10Click(Object sender, RoutedEventArgs e)
        {
            var uri = "https://www.anapioficeandfire.com/" + "api/houses?pageSize=" + 10;
            Frame.Navigate(typeof(HousesPage), uri);
        }
        // 15 houses / page
        private void hasteg15Click(Object sender, RoutedEventArgs e)
        {
            var uri = "https://www.anapioficeandfire.com/" + "api/houses?pageSize=" + 15;
            Frame.Navigate(typeof(HousesPage), uri);
        }

    }
}
