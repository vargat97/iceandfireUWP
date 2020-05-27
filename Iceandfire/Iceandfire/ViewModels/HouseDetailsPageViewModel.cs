using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.ViewModels
{
    public class HouseDetailsPageViewModel
    {
        public NotifyTaskCompletion<House> NotifyHouse { get; }
        public NotifyTaskCompletion<Character> NotifyCurrentLord { get; }
        public NotifyTaskCompletion<Character> NotifyHeir { get; }
        public NotifyTaskCompletion<House> NotifyOverLord { get; }
        public NotifyTaskCompletion<Character> NotifyFounder { get; }



        public HouseDetailsPageViewModel() { }

        public HouseDetailsPageViewModel(House house) {
            var service = new HouseService();
            var cService = new CharacterService();
           
            NotifyHouse = new NotifyTaskCompletion<House>(service.GetHouseAsync(house.url));

            NotifyCurrentLord = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(house.currentLord));

            //NotifyHeir = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(house.heir));

            NotifyOverLord = new NotifyTaskCompletion<House>(service.GetHouseAsync(house.overlord));
            NotifyFounder = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(house.founder));
        }
    }
}
