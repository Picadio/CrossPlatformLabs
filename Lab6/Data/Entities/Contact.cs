using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.Entities;

public class Contact
{
    [Key]
    public Guid ContactId { get; set; }
    public Guid ContactTypeCode { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactWorkPhoneNumber { get; set; }
    public string ContactCellPhoneNumber { get; set; }
    public string ContactOtherDetails { get; set; }
    
    public RefContactType ContactType { get; set; }
}