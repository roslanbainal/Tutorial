using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Entities
{
    public class AuthorInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Since { get; set; }
        public string Academic { get; set; }
        public string PhotoUrl { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
