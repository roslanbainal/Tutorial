using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Entities;

namespace Tutorial.ViewModel.Book
{
    public class BookDetailViewModel
    {
        public int BookId { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public string[] CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
