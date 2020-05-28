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
    public sealed partial class HouseDetailsPage : Page
    {
        public HouseDetailsPage()
        {
            this.InitializeComponent();
        }
        // just for set the appropriate viewmodel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var url = (House)e.Parameter;
            DataContext = new HouseDetailsPageViewModel(url);
            base.OnNavigatedTo(e);
        }

        // sworn member character click event handling
        private void Sworn_Click(object sender, ItemClickEventArgs e)
        {
                var character = (Character)e.ClickedItem;
                Frame.Navigate(typeof(CharacterDetailsPage), character);
        }
        // heir character clicked event handling
        private void Heir_Click(object sender, RoutedEventArgs e)
        {
            HouseDetailsPageViewModel vm = (HouseDetailsPageViewModel)DataContext;
            if(vm.NotifyHeir != null)
            {
                Character c = vm.NotifyHeir.Result;
                Frame.Navigate(typeof(CharacterDetailsPage), c);
            }

        }
        //current lord character clicked event handling
        private void cLord_Click(object sender, RoutedEventArgs e)
        {
            HouseDetailsPageViewModel vm = (HouseDetailsPageViewModel)DataContext;
            Character c = vm.NotifyCurrentLord.Result;
            if (!c.url.Equals(""))
                Frame.Navigate(typeof(CharacterDetailsPage), c);
        }
        //overlord house clicked event handling
        private void OverLord_click(object sender, RoutedEventArgs e)
        {
            HouseDetailsPageViewModel vm = (HouseDetailsPageViewModel)DataContext;
            House h = vm.NotifyHouse.Result.overLordC;
            if (!h.url.Equals(""))
                Frame.Navigate(typeof(HouseDetailsPage), h);
        }
        //founder character clicked event handling
        private void Founder_Click(object sender, RoutedEventArgs e)
        {
            HouseDetailsPageViewModel vm = (HouseDetailsPageViewModel)DataContext;
            Character c = vm.NotifyHouse.Result.founderC;
            if (!c.url.Equals(""))
                Frame.Navigate(typeof(CharacterDetailsPage), c);
        }
    }
}
