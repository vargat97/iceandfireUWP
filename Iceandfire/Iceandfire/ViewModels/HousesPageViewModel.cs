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

        public HousesPageViewModel()
        {
            var service = new HouseService();
            NotifyHouses = new NotifyTaskCompletion<List<House>>(service.GetHousesAsync());
        }

    }
}
