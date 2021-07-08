using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.ViewModel.Author
{
    public class CreateUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Since { get; set; }
        [Required]
        public string Academic { get; set; }
        [Required]
        [RegularExpression(@"(https?:\/\/[^ ]*\.(?:gif|png|jpg|jpeg))", ErrorMessage = "Image format png,jpeg,jpg only")]
        public string PhotoUrl { get; set; }
    }
}
