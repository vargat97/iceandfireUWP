using Iceandfire.Models;
using Iceandfire.Services;
using Iceandfire.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace Iceandfire.ViewModels
{
    public class BooksPageViewModel
    {
        
        public NotifyTaskCompletion<List<Book>> NotifyBooks { get; }
        public BookService Service { get; set; } = new BookService();
       

        public BooksPageViewModel()
        {
            
            NotifyBooks = new NotifyTaskCompletion<List<Book>>(Service.GetBooksAsync());
        }
        public BooksPageViewModel(string uri)
        {
            
            NotifyBooks = new NotifyTaskCompletion<List<Book>>(Service.GetBooksAsync(uri));
        }
    }
}
