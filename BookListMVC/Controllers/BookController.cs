using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookListMVCDbContext _db;
        public BookController(BookListMVCDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }
        [BindProperty]
        public Book Book { get; set; }

        public IActionResult Index()
        {
            Books = _db.Books.ToList();
            var model = new BookListViewModel
            {
                Books = Books
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            Console.WriteLine(ModelState);
            var req = Request;
            if (ModelState.IsValid)
            {
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Book");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _db.Books.FindAsync(id);
            var model = new EditViewModel
            {
                EditBook = book
            };
            if (book == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book EditBook, int id)
        {
            var selectedBook = await _db.Books.FindAsync(id);
            if (ModelState.IsValid)
            {
                return NotFound();
            }
            selectedBook.Name = EditBook.Name;
            selectedBook.Author = EditBook.Author;
            selectedBook.Page = EditBook.Page;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }

    }
}
