using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Models
{
    /*  Data class, represents a Character.
    *  Pasted JSON as Class
    */
    public class Character
    {
        public string url { get; set; }
        public string name { get; set; }
        public string culture { get; set; }
        public string born { get; set; }
        public string died { get; set; }
        public string[] titles { get; set; }
        public string[] aliases { get; set; }
        public string father { get; set; }
        public string mother { get; set; }
        public string spouse { get; set; }
        public string[] allegiances { get; set; }
        public string[] books { get; set; }
        public string[] povBooks { get; set; }
        public string[] tvSeries { get; set; }
        public string[] playedBy { get; set; }
        public Character fatherC { get; set; }
        public Character motherC { get; set; }
        public Character spouseC { get; set; }
        public List<House> allegiancesList { get; set; } = new List<House>();
        public List<Book> booksList { get; set; } = new List<Book>();
        public List<Book> povBookList { get; set; } = new List<Book>();
    }
}
