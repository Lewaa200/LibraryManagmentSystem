using System.Net;
using Data.Repository;
using Data.Models;
using Data.Utilities;

namespace LIBAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<PaginatedList<Book>> GetBooksAsync(int pageIndex, int pageSize, string sortOrder);

        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }

    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
    }

    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }

    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
    }

    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync();
        Task<BookCategory> GetBookCategoryByIdAsync(int bookId, int categoryId);
        Task AddBookCategoryAsync(BookCategory bookCategory);
        Task UpdateBookCategoryAsync(BookCategory bookCategory);
        Task DeleteBookCategoryAsync(int bookId, int categoryId);
    }


}
