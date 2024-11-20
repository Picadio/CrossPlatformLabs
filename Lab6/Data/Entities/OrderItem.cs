using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class OrderItem
{
    [Key]
    public int ItemNumber { get; set; }
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public double ItemAgreedPrice { get; set; }
    public string ItemComment { get; set; }
    
    public Order Order { get; set; }
    public Book Book { get; set; }
}