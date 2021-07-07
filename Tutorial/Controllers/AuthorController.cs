using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Services;

namespace Tutorial.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _service;

        public AuthorController(AuthorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ListAuthor() {

            var authors = await _service.GetAuthors();
            return View(authors);
        }

        public async Task<IActionResult> Author(int id)
        {

            var authors = await _service.GetAuthor(id);
            return View(authors);
        }

        public async Task<IActionResult> AuthorBooks(int id)
        {

            var books = await _service.GetBooks(id);
            return View(books);
        }
    }
}
