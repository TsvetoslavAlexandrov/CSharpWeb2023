namespace Forum.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.EntityValidations.Post;

public class Post
{
    public Post()
    {
        this.Id = Guid.NewGuid();
    }
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; }

    [Required]
    [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
    public string Content { get; set; }


}