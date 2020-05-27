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

        public CharactersPageViewModel()
        {
            var service = new CharacterService();
            NotifyCharacters = new NotifyTaskCompletion<List<Character>>(service.GetCharactersAsync());
        }
    }
}
