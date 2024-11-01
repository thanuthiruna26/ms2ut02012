
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.BookCategories;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IBookCategoryRepo _bookCategoryRepo;

        public BookCategoriesController(IBookCategoryRepo bookCategoryRepo)
        {
            _bookCategoryRepo = bookCategoryRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var books = _bookCategoryRepo.GetAll();
            return Ok(books);
        }

        [HttpGet("{CategoryId}")]
        public IActionResult GetById(int CategoryId)
        {
            var books = _bookCategoryRepo.GetById(CategoryId);
            if (books == null)
                return NotFound();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Create(BookCategoryResponse bookCategoryResponse)
        {
            var books = new BookCategories
            {
                CategoryName = bookCategoryResponse.CategoryName,
               
            };
            _bookCategoryRepo.Add(books);
            return CreatedAtAction(nameof(GetById), new { CategoryId = books.CategoryId }, books);
        }

        [HttpPut("{CategoryId}")]
        public IActionResult Update(int CategoryId, BookCategoryResponse BookCategoryResponse)
        {
            var bookCategories = _bookCategoryRepo.GetById(CategoryId);
            if (bookCategories == null)
                return NotFound();

            bookCategories.CategoryName = BookCategoryResponse.CategoryName;

            _bookCategoryRepo.Update(bookCategories);

            return NoContent();
        }

        [HttpDelete("{CategoryId}")]
        public IActionResult Delete(int CategoryId)
        {
            var bookCategories = _bookCategoryRepo .GetById(CategoryId);
            if (bookCategories == null)
                return NotFound();

            _bookCategoryRepo.Delete(CategoryId);
            return NoContent();
        }
    }
}
