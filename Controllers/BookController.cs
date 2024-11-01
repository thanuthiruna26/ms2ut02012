using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.BookCategories;
using WebApplication1.DTO.Books;
using WebApplication1.Repository;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BooksRepo _booksRepo;

        public BookController(BooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var books = _booksRepo.GetAll();
            return Ok(books);
        }

        [HttpGet("{BookId}")]
        public IActionResult GetById(int BookId)
        {
            var books = _booksRepo.GetById(BookId);
            if (books == null)
                return NotFound();
            return Ok(books);
        }


        [HttpPost]
        public IActionResult Create(BookResponse bookResponse)
        {
            var books = new Books
            {
                Title = bookResponse.Title,

            };
            _booksRepo.Add(books);
            return CreatedAtAction(nameof(GetById), new { BookId = books.BookId }, books);
        }

        [HttpPut("{BookId}")]
        public IActionResult Update(int BookId, BookResponse BookResponse)
        {
            var books = _booksRepo.GetById(BookId);
            if (books == null)
                return NotFound();

            books.Title = BookResponse.Title;

            _booksRepo.Update(books);

            return NoContent();
        }

        [HttpDelete("{BookId}")]
        public IActionResult Delete(int BookId)
        {
            var books = _booksRepo.GetById(BookId);
            if (books == null)
                return NotFound();

            _booksRepo.Delete(BookId);
            return NoContent();
        }
    }
}
