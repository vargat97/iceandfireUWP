using Iceandfire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Services
{
    class BookService : Service
    {
        //Get all the Books async
        public async Task<List<Book>> GetBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books?pageSize=5"));
        }
        //Get 1 book by uri
        public async Task<Book> GetBookAsync(string url)
        {
            return await GetAsync<Book>(new Uri(url));
        }
    }
}
