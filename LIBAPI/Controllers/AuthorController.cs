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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorDTOs = _mapper.Map<IEnumerable<AuthorDTO>>(authors);
            return Ok(authorDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return Ok(authorDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            await _authorService.AddAuthorAsync(author);
            var createdAuthorDTO = _mapper.Map<AuthorDTO>(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthorDTO.ID }, createdAuthorDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDTO authorDTO)
        {
            if (id != authorDTO.ID)
            {
                return BadRequest();
            }

            var author = _mapper.Map<Author>(authorDTO);
            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
