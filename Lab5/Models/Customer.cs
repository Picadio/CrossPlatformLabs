using System.Text.Json.Serialization;

namespace Lab5.Models;

public class Customer
{
    [JsonPropertyName("customerId")]
    public Guid CustomerId { get; set; }
    [JsonPropertyName("customerCode")]
    public string CustomerCode { get; set; }
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }
    [JsonPropertyName("customerAddress")]
    public string CustomerAddress { get; set; }
    [JsonPropertyName("customerPhone")]
    public string CustomerPhone { get; set; }
    [JsonPropertyName("customerEmail")]
    public string CustomerEmail { get; set; }
}