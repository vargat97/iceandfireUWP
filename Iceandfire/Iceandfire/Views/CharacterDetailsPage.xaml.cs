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
    public sealed partial class CharacterDetailsPage : Page
    {
        public CharacterDetailsPage()
        {
            this.InitializeComponent();
        }
        //just for set the appropriate viewmodel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var url = (Character)e.Parameter;
            DataContext = new CharacterDetailsPageViewModel(url);
            base.OnNavigatedTo(e);
        }
        // Character clicked event handling
        private void ListView_ItemClick_Book(object sender, ItemClickEventArgs e)
        {
            var clickedBook = (Book)e.ClickedItem;
            Frame.Navigate(typeof(BookDetailsPage), clickedBook);
        }
        // House clicked event handling
        private void ListView_ItemClick_House(object sender, ItemClickEventArgs e)
        {
            var clickedHouse = (House)e.ClickedItem;
            Frame.Navigate(typeof(HouseDetailsPage), clickedHouse);
        }
    }
}
