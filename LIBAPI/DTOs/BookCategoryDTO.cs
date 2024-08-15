namespace LIBAPI.DTOs
{
    public class BookCategoryDTO
    {
        public int BookId { get; set; }
        public BookDTO Book { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }

}
