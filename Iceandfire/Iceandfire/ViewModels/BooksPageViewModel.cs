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

        //NotifyTaskCompletion property for propertychanged event
        public NotifyTaskCompletion<List<Book>> NotifyBooks { get; }
        //Service property, for ask the service links
        public BookService Service { get; set; } = new BookService();

        // Constructor which set the property
        public BooksPageViewModel()
        {
            
            NotifyBooks = new NotifyTaskCompletion<List<Book>>(Service.GetBooksAsync());
        }
        // Constructor which set the property
        public BooksPageViewModel(string uri)
        {
            
            NotifyBooks = new NotifyTaskCompletion<List<Book>>(Service.GetBooksAsync(uri));
        }
    }
}
