using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Entities
{
    public class Book
    {
        public Book() {
            CreatedAt = DateTime.Now;
            Categories = new HashSet<BookCategory>();
        }

        public int Id { get; set; }

        public string BookName { get; set; }

        public DateTime CreatedAt { get; set; } 

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BookCategory> Categories { get; set; }
    }
}
