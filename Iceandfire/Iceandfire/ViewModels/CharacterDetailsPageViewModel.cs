using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.ViewModels
{
    public class CharacterDetailsPageViewModel
    {

        //A lot of NotifyTaskCompletion property, because characters have a lot of other models data
        public NotifyTaskCompletion<Character> NotifyCharacter{get;}
        public NotifyTaskCompletion<List<Character>> NotifyFather { get; private set; }
        public NotifyTaskCompletion<Character> NotifyMother { get; private set; }
        public NotifyTaskCompletion<Character> NotifySpouse { get; private set; }
        public NotifyTaskCompletion<List<Book>> NotifyBooks { get; private set; }
        public NotifyTaskCompletion<House> NotifyAllegiances { get; private set; }
        public List<NotifyTaskCompletion<Book>> NotifyPovBooks { get; set; }

        public CharacterDetailsPageViewModel() { }

        // Constructor which set the properties
        public CharacterDetailsPageViewModel(Character character)
        {
            var cService = new CharacterService();
            var hService = new HouseService();
            var bService = new BookService();
            NotifyCharacter = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.url));

            NotifyFather = new NotifyTaskCompletion<List<Character>>(cService.GetCharactersAsync(character.father));

            NotifyMother = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.mother));
            NotifySpouse = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.spouse));
            if(character.allegiances.Length >0)
            NotifyAllegiances = new NotifyTaskCompletion<House>(hService.GetHouseAsync(character.allegiances[0]));

            
        }
    }
}
