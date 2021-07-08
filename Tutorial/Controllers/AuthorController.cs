using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Services;
using Tutorial.ViewModel.Author;

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

        public async Task<IActionResult> CreateUpdate(int id) {
            var author = await _service.CreateUpdateAuthor(id);
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(CreateUpdateViewModel model) {

            if (ModelState.IsValid) {
                await _service.Save(model);
                return RedirectToAction("ListAuthor");
            }
            return View(model);
        }
    }
}
