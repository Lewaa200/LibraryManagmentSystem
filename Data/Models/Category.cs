

namespace Data.Models
{
    public class Category
    {
        public int ID { get; set; }  // Primary key
        public string Name { get; set; }
        public DateTime? InactiveDate { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
