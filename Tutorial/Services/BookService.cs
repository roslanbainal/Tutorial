using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Data;
using Tutorial.Entities;
using Tutorial.ViewModel;

namespace Tutorial.Services
{
    public class BookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BookDetailViewModel>> GetBooks() {      

            var query = await _context.Book
                .Include(x=>x.Categories).ThenInclude(c=>c.Category)
                .Include(x=>x.Author)
                .Select(b => new BookDetailViewModel
                {
                    AuthorName = b.Author.AuthorName,
                    BookId = b.Id,
                    BookName = b.BookName,
                    CategoryName = b.Categories.Where(x => x.CategoryId == x.Category.Id).Select(x => x.Category.CategoryName).ToArray(),
                    CreatedAt = b.CreatedAt
                }).ToListAsync();

            return query;
        }

        public async Task<FullBookDetailViewModel> GetBookById(int id)
        {
            var query = await _context.Book
                .Where(x=>x.Id == id)
                .Include(x => x.Categories).ThenInclude(c => c.Category)
                .Include(x => x.Author).ThenInclude(a =>a.AuthorInfo)
                .Select(b => new FullBookDetailViewModel
                { 
                    AuthorName = b.Author.AuthorName,
                    Email = b.Author.AuthorInfo.Email,
                    Address = b.Author.AuthorInfo.Address,
                    Academic = b.Author.AuthorInfo.Academic,
                    Since = b.Author.AuthorInfo.Since,
                    CategoryName = b.Categories.Where(x=>x.CategoryId == x.Category.Id).Select(x=>x.Category.CategoryName).ToArray(),
                    CreatedAt = b.CreatedAt,
                    BookName = b.BookName,
                    PhotoUrl = b.Author.AuthorInfo.PhotoUrl
                }).FirstOrDefaultAsync();

            return query;
        }

        public async Task<CreateUpdateBookViewModel> CreateEditBookVM(int? id) {

            var vm = new CreateUpdateBookViewModel();
            List<int> categoryids = new List<int>();

            if (!id.HasValue)
            {
                vm.Authors = await _context.Author.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.AuthorName
                }).ToListAsync();

                vm.Categories = await _context.Category.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                }).ToListAsync();
            }
            else {
                var book = await _context.Book
                    .Include(x => x.Author)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x=>x.Id == id.Value);

                book.Categories.ToList().ForEach(result => categoryids.Add(result.CategoryId));

                vm.Authors = await _context.Author.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.AuthorName
                }).ToListAsync();

                vm.Categories = await _context.Category.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                }).ToListAsync();
                vm.BookId = book.Id;
                vm.CategoryIds = categoryids.ToArray();
                vm.AuthorId = book.AuthorId;
                vm.BookName = book.BookName;
            }
            return vm;

        }

        public async Task AddUpdateBook(CreateUpdateBookViewModel model)
        {
            Book book = new Book();
            List<BookCategory> bookCategories = new List<BookCategory>(); 

            if (model.BookId > 0)
            {
                  book = await _context.Book
                 .Include(x => x.Author)
                 .Include(x => x.Categories)
                 .FirstOrDefaultAsync(x => x.Id == model.BookId);

                book.Categories.ToList().ForEach(result => bookCategories.Add(result));
                _context.BookCategory.RemoveRange(bookCategories);
                await _context.SaveChangesAsync();

                book.AuthorId = model.AuthorId;
                book.BookName = model.BookName;

                if (model.CategoryIds.Length > 0) { 
                    bookCategories = new List<BookCategory>();

                    foreach (var categoryid in model.CategoryIds) {
                        bookCategories.Add(new BookCategory { CategoryId = categoryid, BookId = model.BookId});
                    }

                    book.Categories = bookCategories;
                }

                await _context.SaveChangesAsync();
            }
            else {
                model.BookId = LastId();

                book.BookName = model.BookName;
                book.AuthorId = model.AuthorId;
                book.CreatedAt = DateTime.Now;
                if (model.CategoryIds.Length > 0)
                {
                    foreach (var categoryid in model.CategoryIds)
                    {
                        book.Categories.Add(new BookCategory { CategoryId = categoryid, BookId = model.BookId });
                    }
                }
                _context.Book.Add(book);
                await _context.SaveChangesAsync();
            }

         
        }

        public async Task DeleteBook(int id) {
            var book = await _context.Book.FindAsync(id);
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }

        public int LastId() {
            var max = _context.Book.Max(x=>x.Id);
            return max + 1;
        }

        public async Task<bool> Check(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book != null) return true;
            else return false;
        }
    }
}
