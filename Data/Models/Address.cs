
namespace Data.Models;

public class Address
{
    public int ID { get; set; }  // Primary key
    public string Country { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public DateTime? InactiveDate { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
