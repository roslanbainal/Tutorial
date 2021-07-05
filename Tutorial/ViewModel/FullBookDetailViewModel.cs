using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Entities;

namespace Tutorial.ViewModel
{
    public class FullBookDetailViewModel
    {
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public string[] CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Academic { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Since { get; set; }
    }
}
