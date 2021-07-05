using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Entities
{
    public class Category
    {
        public Category() {
            Categories = new HashSet<BookCategory>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory> Categories { get; set; }
    }
}
