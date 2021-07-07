using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.ViewModel.Book
{
    public class CreateUpdateBookViewModel
    {
        public int  BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public int[] CategoryIds { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
