namespace LIBAPI.DTOs
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? InactiveDate { get; set; }
        public ICollection<BookCategoryDTO> BookCategories { get; set; }
    }

}
