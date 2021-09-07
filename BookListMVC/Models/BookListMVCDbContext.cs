using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Models
{
    public class BookListMVCDbContext : DbContext
    {
        public BookListMVCDbContext(DbContextOptions<BookListMVCDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
