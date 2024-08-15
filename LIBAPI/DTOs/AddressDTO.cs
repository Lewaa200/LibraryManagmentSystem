namespace LIBAPI.DTOs
{
    public class AddressDTO
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int AuthorId { get; set; }
    }

}
