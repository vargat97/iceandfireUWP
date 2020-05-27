using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Iceandfire.ViewModels
{
    public class BookDetailsPageViewModel
    {
     
 
        public NotifyTaskCompletion<Book> NotifyBook {
            get;
           
        }
        public NotifyTaskCompletion<List<Character>> NotifyCharacters { get; private set; }
        public NotifyTaskCompletion<List<Character>> NotifyPovCharacters { get; private set; }

        public BookDetailsPageViewModel() { }

        public BookDetailsPageViewModel(Book book)
        {
            var service = new BookService();
            var cService = new CharacterService();
            NotifyBook = new NotifyTaskCompletion<Book>(service.GetBookAsync(book.url));
            

            NotifyCharacters = new NotifyTaskCompletion<List<Character>>(cService.GetCharactersAsync("api/characters?page=12&pageSize=50"));
            NotifyPovCharacters = new NotifyTaskCompletion<List<Character>>(cService.GetCharactersAsync("api/characters?page=10&pageSize=50"));
        }



    }
}
