using Data.Models;


namespace LIBAPI.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IGenericRepository<BookCategory> _bookCategoryRepository;

        public BookCategoryService(IGenericRepository<BookCategory> bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync()
        {
            return await _bookCategoryRepository.GetAllAsync();
        }

        public async Task<BookCategory> GetBookCategoryByIdAsync(int bookId, int categoryId)
        {
            var bookCategories = await _bookCategoryRepository.FindAsync(bc => bc.BookId == bookId && bc.CategoryId == categoryId);
            return bookCategories.FirstOrDefault();
        }

        public async Task AddBookCategoryAsync(BookCategory bookCategory)
        {
            await _bookCategoryRepository.AddAsync(bookCategory);
        }

        public async Task UpdateBookCategoryAsync(BookCategory bookCategory)
        {
            await _bookCategoryRepository.UpdateAsync(bookCategory);
        }

        public async Task DeleteBookCategoryAsync(int bookId, int categoryId)
        {
            var bookCategory = await GetBookCategoryByIdAsync(bookId, categoryId);
            if (bookCategory != null)
            {
                await _bookCategoryRepository.DeleteAsync(bookCategory.BookId);
            }
        }
    }
}
