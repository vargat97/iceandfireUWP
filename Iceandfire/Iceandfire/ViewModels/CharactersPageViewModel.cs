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
        public NotifyTaskCompletion<List<Character>> NotifyCharacters { get; }
        public CharacterService Service { get; set; } = new CharacterService();

        public CharactersPageViewModel()
        {
            
            NotifyCharacters = new NotifyTaskCompletion<List<Character>>(Service.GetCharactersAsync());
        }
        public CharactersPageViewModel(string uri)
        {

            NotifyCharacters = new NotifyTaskCompletion<List<Character>>(Service.GetCharactersAsync(uri));
        }
    }
}
