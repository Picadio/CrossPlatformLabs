using System.Text.Json.Serialization;

namespace Lab5.Models;

public class Book
{
    [JsonPropertyName("bookId")]
    public Guid BookId { get; set; }
    [JsonPropertyName("authorId")]
    public Guid AuthorId { get; set; }
    [JsonPropertyName("bookCategoryCode")]
    public Guid BookCategoryCode { get; set; }
    [JsonPropertyName("isbn")]
    public string ISBN { get; set; }
    [JsonPropertyName("dateOfPublication")]
    public DateTime DateOfPublication { get; set; }
    [JsonPropertyName("dateAcquired")]
    public DateOnly DateAcquired { get; set; }
    [JsonPropertyName("bookTitle")]
    public string BookTitle { get; set; }
    [JsonPropertyName("bookRecommendedPrice")]
    public double BookRecommendedPrice { get; set; }
    [JsonPropertyName("bookComments")]
    public string BookComments { get; set; }
    
    [JsonPropertyName("bookCategory")]
    public BookCategory BookCategory { get; set; }
    [JsonPropertyName("author")]
    public Author Author { get; set; }
}