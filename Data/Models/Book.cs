



namespace Data.Models
{


    public class Book
    {
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
        }
        public int ID { get; set; }  // Primary key
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? InactiveDate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }

    }

}
