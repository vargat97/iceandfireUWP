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
        //Get all the Characters async
        //Parameter for get the right pagesize and pagenumber
        public async Task<List<Character>> GetCharactersAsync(string uri)
        {
            return await GetAsync<List<Character>>(new Uri(uri));
        }
        //Get a single Character by an URI
        public async Task<Character> GetCharacterAsync(string UriId)
        {
            //get the character asynch
            Character c = await GetAsync<Character>(new Uri(UriId));

            //and fill the properties with data
            if(!c.father.Equals(""))
            {
                // asynch call for fater
                c.fatherC = await GetAsync<Character>(new Uri(c.father));
            }
            if(!c.mother.Equals(""))
            {
                // asynch call for mother
                c.motherC = await GetAsync<Character>(new Uri(c.mother));
            }
            if(!c.spouse.Equals(""))
            {
                // asynch call for spouse
                c.spouseC = await GetAsync<Character>(new Uri(c.spouse));
            }
            foreach(string s in c.allegiances)
            {
                // asynch call for allegiances
                House h = await GetAsync<House>(new Uri(s));
                c.allegiancesList.Add(h);
            }
            foreach(string s in c.books)
            {
                // asynch call for books
                c.booksList.Add(await GetAsync<Book>(new Uri(s)));
            }
            foreach(string s in c.povBooks){
                // asynch call for povBooks
                c.povBookList.Add(await GetAsync<Book>(new Uri(s)));
            }
            return c;
        }


    }
}
