using Iceandfire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Services
{
    public class CharacterService:Service
    {

        //Get all the Characters async
        public async Task<List<Character>> GetCharactersAsync()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters?page=12&pageSize=5"));
        }
        //Get the next page Characters async. It can be used after the first page loaded.
        public async Task<List<Character>> GetNextCharactersAsync(string uri)
        {
            return await GetAsync<List<Character>>(new Uri(uri));
        }

        public async Task<List<Character>> GetCharactersAsync(string uri)
        {
            return await GetAsync<List<Character>>(new Uri(uri));
        }
        //Get a single Character by an URI
        public async Task<Character> GetCharacterAsync(string UriId)
        {
            return await GetAsync<Character>(new Uri(UriId));
        }


    }
}
