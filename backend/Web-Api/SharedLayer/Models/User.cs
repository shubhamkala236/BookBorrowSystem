using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLayer.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tokens Available is Required")]
        public int TokensAvailable { get; set; }

        //navigation property
        [JsonIgnore]
        public virtual ICollection<Book> BorrowedBooksList { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> LentBooksList { get; set; }

    }
}
