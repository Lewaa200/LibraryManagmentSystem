using LIBAPI.Services;
using AutoMapper;
using Data.Models;
using LIBAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;
        private readonly IMapper _mapper;

        public BookCategoriesController(IBookCategoryService bookCategoryService, IMapper mapper)
        {
            _bookCategoryService = bookCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategoryDTO>>> GetBookCategories()
        {
            var bookCategories = await _bookCategoryService.GetAllBookCategoriesAsync();
            var bookCategoryDTOs = _mapper.Map<IEnumerable<BookCategoryDTO>>(bookCategories);
            return Ok(bookCategoryDTOs);
        }

        [HttpGet("{bookId}/{categoryId}")]
        public async Task<ActionResult<BookCategoryDTO>> GetBookCategory(int bookId, int categoryId)
        {
            var bookCategory = await _bookCategoryService.GetBookCategoryByIdAsync(bookId, categoryId);
            if (bookCategory == null)
            {
                return NotFound();
            }

            var bookCategoryDTO = _mapper.Map<BookCategoryDTO>(bookCategory);
            return Ok(bookCategoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult<BookCategoryDTO>> PostBookCategory(BookCategoryDTO bookCategoryDTO)
        {
            var bookCategory = _mapper.Map<BookCategory>(bookCategoryDTO);
            await _bookCategoryService.AddBookCategoryAsync(bookCategory);

            var createdBookCategoryDTO = _mapper.Map<BookCategoryDTO>(bookCategory);
            return CreatedAtAction(nameof(GetBookCategory), new { bookId = createdBookCategoryDTO.BookId, categoryId = createdBookCategoryDTO.CategoryId }, createdBookCategoryDTO);
        }

        [HttpPut("{bookId}/{categoryId}")]
        public async Task<IActionResult> PutBookCategory(int bookId, int categoryId, BookCategoryDTO bookCategoryDTO)
        {
            if (bookId != bookCategoryDTO.BookId || categoryId != bookCategoryDTO.CategoryId)
            {
                return BadRequest();
            }

            var bookCategory = _mapper.Map<BookCategory>(bookCategoryDTO);
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
