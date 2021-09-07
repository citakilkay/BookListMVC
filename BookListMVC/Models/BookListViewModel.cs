using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Book Book { get; set; }
    }
}
