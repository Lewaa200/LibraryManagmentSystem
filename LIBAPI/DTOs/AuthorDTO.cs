namespace LIBAPI.DTOs
{
    public class AuthorDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? InactiveDate { get; set; }
        public AddressDTO Address { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }

}
