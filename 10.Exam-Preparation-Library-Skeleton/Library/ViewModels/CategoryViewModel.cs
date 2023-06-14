using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;


    }
}

// Has Id – a unique integer, Primary Key
// Has Name – a string with min length 5 and max length 50 (required)
// Has Books – a collection of type Books