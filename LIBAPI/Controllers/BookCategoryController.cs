using LIBAPI.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoriesController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategory>>> GetBookCategories()
        {
            var bookCategories = await _bookCategoryService.GetAllBookCategoriesAsync();
            return Ok(bookCategories);
        }

        [HttpGet("{bookId}/{categoryId}")]
        public async Task<ActionResult<BookCategory>> GetBookCategory(int bookId, int categoryId)
        {
            var bookCategory = await _bookCategoryService.GetBookCategoryByIdAsync(bookId, categoryId);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return Ok(bookCategory);
        }

        [HttpPost]
        public async Task<ActionResult<BookCategory>> PostBookCategory(BookCategory bookCategory)
        {
            await _bookCategoryService.AddBookCategoryAsync(bookCategory);
            return CreatedAtAction(nameof(GetBookCategory), new { bookId = bookCategory.BookId, categoryId = bookCategory.CategoryId }, bookCategory);
        }

        [HttpPut("{bookId}/{categoryId}")]
        public async Task<IActionResult> PutBookCategory(int bookId, int categoryId, BookCategory bookCategory)
        {
            if (bookId != bookCategory.BookId || categoryId != bookCategory.CategoryId)
            {
                return BadRequest();
            }

            await _bookCategoryService.UpdateBookCategoryAsync(bookCategory);
            return NoContent();
        }

        [HttpDelete("{bookId}/{categoryId}")]
        public async Task<IActionResult> DeleteBookCategory(int bookId, int categoryId)
        {
            await _bookCategoryService.DeleteBookCategoryAsync(bookId, categoryId);
            return NoContent();
        }
    }
}
