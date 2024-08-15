using Data.Models;
using Data.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace LIBAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookService(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<PaginatedList<Book>> GetBooksAsync(int pageIndex, int pageSize, string sortOrder)
        {
            var query = await _bookRepository.GetAllAsync();

            switch (sortOrder)
            {
                case "title_desc":
                    query = query.OrderByDescending(b => b.Title);
                    break;
                case "title_asc":
                default:
                    query = query.OrderBy(b => b.Title);
                    break;
            }

            return await PaginatedList<Book>.CreateAsync(query.AsQueryable(), pageIndex, pageSize);
        }
    }
}
