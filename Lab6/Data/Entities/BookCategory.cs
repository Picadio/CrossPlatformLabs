using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class BookCategory
{
    [Key]
    public Guid BookCategoryCode { get; set; }
    public string BookCategoryDescription { get; set; }
}