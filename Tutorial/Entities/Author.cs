using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public AuthorInfo AuthorInfo { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
