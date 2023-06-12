using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        public string CollectorId { get; set; }

        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;


        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}