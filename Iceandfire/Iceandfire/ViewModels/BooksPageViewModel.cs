using Iceandfire.Models;
using Iceandfire.Services;
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
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public NotifyTaskCompletion<List<Book>> NotifyBooks { get; }

        public BooksPageViewModel()
        {
            var service = new BookService();
            NotifyBooks = new NotifyTaskCompletion<List<Book>>(service.GetBooksAsync());
        }
       
    }
}
