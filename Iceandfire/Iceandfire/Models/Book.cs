using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Models
{
    /*  Data class, represents a Book.
     *  Pasted JSON as Class
        */
    public class Book
        {
            public string url { get; set; }
            public string name { get; set; }
            public string isbn { get; set; }
            public string[] authors { get; set; }
            public int numberOfPages { get; set; }
            public string publisher { get; set; }
            public string country { get; set; }
            public string mediaType { get; set; }
            public DateTime released { get; set; }
            public string[] characters { get; set; }
            public string[] povCharacters { get; set; }
        // List for helping to get the character object from the book
            public List<Character> charactersList { get; set; } = new List<Character>();
            public List<Character> povCharactersList { get; set; } = new List<Character>();
    }
}
