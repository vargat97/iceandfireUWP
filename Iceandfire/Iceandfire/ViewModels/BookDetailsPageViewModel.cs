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
     
        //NotifyTaskCompletion property for propertychanged event
        public NotifyTaskCompletion<Book> NotifyBook {get;}


        public BookDetailsPageViewModel() { }

        // Constructor which set the property
        public BookDetailsPageViewModel(Book book)
        {
            var service = new BookService();
            var cService = new CharacterService();
            NotifyBook = new NotifyTaskCompletion<Book>(service.GetBookAsync(book.url));   
      }



    }
}
