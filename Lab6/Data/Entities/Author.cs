using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class Author
{
    [Key]
    public Guid AuthorId { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorInitials { get; set; }
    public string AuthorLastName { get; set; }
    public DateOnly AuthorDateOfBirth { get; set; }
    public string AuthorGenderMFU { get; set; }
    public string AuthorContactDetails { get; set; }
    public string AuthorOtherDetails { get; set; }
}