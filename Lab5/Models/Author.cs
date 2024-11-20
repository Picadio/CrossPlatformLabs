using System.Text.Json.Serialization;

namespace Lab5.Models;

public class Author
{
    [JsonPropertyName("authorId")]
    public Guid AuthorId { get; set; }
    [JsonPropertyName("authorFirstName")]
    public string AuthorFirstName { get; set; }
    [JsonPropertyName("authorInitials")]
    public string AuthorInitials { get; set; }
    [JsonPropertyName("authorLastName")]
    public string AuthorLastName { get; set; }
    [JsonPropertyName("authorDateOfBirth")]
    public DateOnly AuthorDateOfBirth { get; set; }
    [JsonPropertyName("authorGenderMFU")]
    public string AuthorGenderMFU { get; set; }
    [JsonPropertyName("authorContactDetails")]
    public string AuthorContactDetails { get; set; }
    [JsonPropertyName("authorOtherDetails")]
    public string AuthorOtherDetails { get; set; }
}