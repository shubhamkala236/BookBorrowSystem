using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLayer.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "BookName is Required")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Genre is Required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Availibility is Required")]
        public string IsBookAvailable { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public int? LentByUserId { get; set; }
        public int? BorrowedByUserId { get; set; }

        //Navigation properties
        [JsonIgnore]
        public virtual User LentByUser { get; set; }
        [JsonIgnore]
        public virtual User BorrowedByUser { get; set; }

    }
}
