

namespace Data.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int ID { get; set; }  // Primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? InactiveDate { get; set; }

        public Address Address { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
