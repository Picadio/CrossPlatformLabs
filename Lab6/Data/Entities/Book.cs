using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class Book
{
    [Key]
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    public Guid BookCategoryCode { get; set; }
    public string ISBN { get; set; }
    public DateOnly DateOfPublication { get; set; }
    public DateOnly DateAcquired { get; set; }
    public string BookTitle { get; set; }
    public double BookRecommendedPrice { get; set; }
    public string BookComments { get; set; }
    
    public Author Author { get; set; }
    public BookCategory BookCategory { get; set; }
}