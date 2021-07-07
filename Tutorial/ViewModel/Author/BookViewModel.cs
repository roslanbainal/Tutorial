using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.ViewModel.Author
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string[] CategoryName { get; set; }
    }
}
