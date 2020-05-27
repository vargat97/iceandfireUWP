using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.ViewModels
{
    public class CharacterDetailsPageViewModel
    {

        public NotifyTaskCompletion<Character> NotifyCharacter{get;}
        public NotifyTaskCompletion<Character> NotifyFather { get; private set; }
        public NotifyTaskCompletion<Character> NotifyMother { get; private set; }
        public NotifyTaskCompletion<Character> NotifySpouse { get; private set; }
        public NotifyTaskCompletion<List<Book>> NotifyBooks { get; private set; }
        //public NotifyTaskCompletion<House> NotifyAllegiances { get; private set; }


        public CharacterDetailsPageViewModel() { }

        public CharacterDetailsPageViewModel(Character character)
        {
            var cService = new CharacterService();
            NotifyCharacter = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.url));
            NotifyFather = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.father));
            NotifyMother = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.mother));
            NotifySpouse = new NotifyTaskCompletion<Character>(cService.GetCharacterAsync(character.spouse));
        }
    }
}
