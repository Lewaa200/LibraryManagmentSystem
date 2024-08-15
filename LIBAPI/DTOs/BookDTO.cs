namespace LIBAPI.DTOs
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int AuthorId { get; set; }
        public AuthorDTO Author { get; set; }
        public ICollection<BookCategoryDTO> BookCategories { get; set; }
    }
}
