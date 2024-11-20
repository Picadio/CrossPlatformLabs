using System.Text.Json.Serialization;

namespace Lab5.Models;

public class BookCategory
{
    [JsonPropertyName("bookCategoryCode")]
    public Guid BookCategoryCode { get; set; }
    [JsonPropertyName("bookCategoryDescription")]
    public string BookCategoryDescription { get; set; }
}