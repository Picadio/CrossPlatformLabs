using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class Customer
{
    [Key]
    public Guid CustomerId { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
}