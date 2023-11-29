using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class AddBookDTO
    {
        [Required(ErrorMessage = "BookName is Required")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Genre is Required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
    }
}
