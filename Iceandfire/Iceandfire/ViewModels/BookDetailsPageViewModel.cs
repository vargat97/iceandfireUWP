using Iceandfire.Models;
using Iceandfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.ViewModels
{
    public class BookDetailsPageViewModel
    {
        public NotifyTaskCompletion<Book> NotifyBook { get; }

        public BookDetailsPageViewModel(string url)
        {
            
            var service = new BookService();
            NotifyBook = new NotifyTaskCompletion<Book>(service.GetBookAsync(url));
        }
    }
}
