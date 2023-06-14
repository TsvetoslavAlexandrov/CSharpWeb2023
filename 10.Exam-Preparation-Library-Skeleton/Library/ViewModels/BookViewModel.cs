using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class BookViewModel
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

        [Range(0.00, 10.00)]
        public decimal? Rating { get; set; } 

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

    }
}
