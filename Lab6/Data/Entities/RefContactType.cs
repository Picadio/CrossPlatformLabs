using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class RefContactType
{
    [Key]
    public Guid ContactTypeCode { get; set; }
    public string ContactTypeDescription { get; set; }
}