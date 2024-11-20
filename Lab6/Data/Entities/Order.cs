using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class Order
{
    [Key]
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public DateOnly OrderDate { get; set; }
    public string OrderValue { get; set; }
    
    public Customer Customer { get; set; }
}