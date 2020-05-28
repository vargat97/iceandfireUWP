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
    public sealed partial class BookDetailsPage : Page
    {
        public BookDetailsPage()
        {           
            this.InitializeComponent();
        }
        // Just for set the Page's viewmodel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                var url = (Book)e.Parameter;
                DataContext = new BookDetailsPageViewModel(url);
                base.OnNavigatedTo(e);
        }

        //Character clicked event handler
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var character = (Character)e.ClickedItem;
            Frame.Navigate(typeof(CharacterDetailsPage), character);
        }
        //povCharacter clicked event handler
        private void ListView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var character = (Character)e.ClickedItem;
            Frame.Navigate(typeof(CharacterDetailsPage), character);
        }
    }
}
