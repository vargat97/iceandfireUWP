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
        public NotifyTaskCompletion<List<House>> NotifyHouses { get; }
        public HouseService Service { get; set; } = new HouseService();

        public HousesPageViewModel()
        {
            
            NotifyHouses = new NotifyTaskCompletion<List<House>>(Service.GetHousesAsync());
        }

        public HousesPageViewModel(string uri)
        {

            NotifyHouses = new NotifyTaskCompletion<List<House>>(Service.GetHousesAsync(uri));
        }
    }
}
