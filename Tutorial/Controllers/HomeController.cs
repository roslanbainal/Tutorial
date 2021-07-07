using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models;
using Tutorial.Services;
using Tutorial.ViewModel;
using Tutorial.ViewModel.Book;

namespace Tutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _service;

        public HomeController(ILogger<HomeController> logger, BookService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _service.GetBooks();
            return View(books);
        }

        public async Task<IActionResult> GetBook(int bookid) {

            var book = await _service.GetBookById(bookid);
            return View(book);
        }

        public async Task<IActionResult> CreateEditBook(int? bookid) {
            return View(await _service.CreateEditBookVM(bookid));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateUpdateBookViewModel model) {
            await _service.AddUpdateBook(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int bookid) {
            await _service.DeleteBook(bookid);
            return RedirectToAction("Index");
        }
       
    }
}
