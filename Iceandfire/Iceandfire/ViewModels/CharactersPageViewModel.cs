using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.ViewModels
{
    public class CharactersPageViewModel
    {
        //NotifyTaskCompletion property for propertychanged event
        public NotifyTaskCompletion<List<Character>> NotifyCharacters { get; }
        //Service property, for ask the service links
        public CharacterService Service { get; set; } = new CharacterService();

        // Constructor which set the property
        public CharactersPageViewModel()
        {
            
            NotifyCharacters = new NotifyTaskCompletion<List<Character>>(Service.GetCharactersAsync());
        }
        // Constructor which set the property
        public CharactersPageViewModel(string uri)
        {

            NotifyCharacters = new NotifyTaskCompletion<List<Character>>(Service.GetCharactersAsync(uri));
        }
    }
}
