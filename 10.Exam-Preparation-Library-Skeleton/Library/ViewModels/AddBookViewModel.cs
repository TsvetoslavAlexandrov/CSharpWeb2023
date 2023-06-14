using System.ComponentModel.DataAnnotations;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.ViewModels
{
    public class AddBookViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}


//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)
//• Has UsersBooks – a collection of type IdentityUserBook

