using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Entities;
using Tutorial.ViewModel.Author;

namespace Tutorial.ViewModel
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Since { get; set; }
        public string Academic { get; set; }
        public string PhotoUrl { get; set; }
        public int TotalBook { get; set; }
        public ICollection<BookViewModel> BookViewModel { get; set; }
    }
}
