using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiMongo.Models;
using BooksApiMongo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApiMongo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService service)
        {
            _bookService = service;
        }

        public async Task<ActionResult<List<Book>>> Get() => await _bookService.Get();

        [HttpGet("{id:length(24)}", Name ="GetBook")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
                return NotFound();

            return book;
        }

        [HttpPost(Name ="register")]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            await _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book bookIn)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
                return NotFound();

            _bookService.Update(id, bookIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book =await _bookService.GetBook(id);
            if (book == null)
                return NotFound();

            _bookService.Remove(book.Id);

            return NoContent();

        }

        [HttpPost("registerAuthor", Name = "registerAuthor")]
        public async Task<IActionResult> CreateAuthor(Author author)
        {
            await _bookService.CreateAuthor(author);

            //return CreatedAtRoute("GetAuthor", new { id = author.Id.ToString() }, author);
            return  CreatedAtRoute("GetAuthor", new { id = author.Id.ToString() }, author); 
        }

        [HttpGet("author/{id}", Name = "GetAuthor")]
        public async Task<ActionResult<Author>> GetAuthor(string id)
        {
            var author = await _bookService.GetAuthor(id);
            if (author == null)
                return NotFound();

            return author;
        }

    }
}