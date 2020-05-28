using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.ViewModels
{
    public class HousesPageViewModel
    {
        //NotifyTaskCompletion property for propertychanged event
        public NotifyTaskCompletion<List<House>> NotifyHouses { get; }
        //Service property, for ask the service links
        public HouseService Service { get; set; } = new HouseService();

        // Constructor which set the properties
        public HousesPageViewModel()
        {
            
            NotifyHouses = new NotifyTaskCompletion<List<House>>(Service.GetHousesAsync());
        }
        // Constructor which set the properties
        public HousesPageViewModel(string uri)
        {

            NotifyHouses = new NotifyTaskCompletion<List<House>>(Service.GetHousesAsync(uri));
        }
    }
}
