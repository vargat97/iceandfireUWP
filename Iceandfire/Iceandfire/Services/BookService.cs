using Iceandfire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Services
{
    public class BookService : Service
    {
        //Get all the Books async
        public async Task<List<Book>> GetBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books?pageSize=5")); ;
        }
        //Get all the Books async
        //Parameter for get the right pagesize and pagenumber
        public async Task<List<Book>> GetBooksAsync(string uri)
        {
            return await GetAsync<List<Book>>(new Uri(uri));
        }

        //Get 1 book by uri
        public async Task<Book> GetBookAsync(string url)
        {
            // get the book async
            Book b = await GetAsync<Book>(new Uri(url));
            //and fill the properties with data
            for(int i = 0; i < 20; i++)
            {
                Character c = await GetAsync<Character>(new Uri(b.characters[i]));
                Character pC;
                if (b.povCharacters.Length > i)
                {
                     pC = await GetAsync<Character>(new Uri(b.povCharacters[i]));
                    b.povCharactersList.Add(pC);
                }
                 
                b.charactersList.Add(c);

            }
    
            return b;
        }
    }
}
