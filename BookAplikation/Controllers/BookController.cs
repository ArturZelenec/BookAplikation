using BookAplikation.Data;
using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookSet _db;
        private readonly IBookManager _bookManager;
        private readonly BookContext _bookContext;

        public BookController(IBookSet db, IBookManager bookManager, BookContext bookContext)
        {
            _db = db;
            _bookManager = bookManager;
            _bookContext = bookContext;
        }

        //public BookController(IBookManager bookManager)
        //{
        //    _bookManager = bookManager;
        //}



        [HttpGet("books/all")]
        public ActionResult<List<GetBookDto>> GetAllBooks()
        {
            return Ok(_bookManager.Get());
        }

       [HttpGet("books/{id:int}", Name = "GetBook")]
        public ActionResult<GetBookDto> GetBookById(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }
            var book = _bookContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
            
            
        }

        //[HttpGet("filter")]
        //public ActionResult<List<GetBookDto>> FilterBookById(FilterBooksRequestDto filterBooksRequestDto)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost("books")]
        public IActionResult PostBook(CreateBookDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            Book model = new Book()
            {
                Title = book.Pavadinimas,
                Author = book.Autorius,
                PublishYear = book.Isleista.Year,
                CoverType = (ECoverType)Enum.Parse(typeof(ECoverType), book.KnygosTypas)

            };

            _bookContext.Books.Add(model);
            _bookContext.SaveChanges();
            return CreatedAtRoute("GetBook", new { id = model.Id }, book);
           
        }

        [HttpPut]
        public IActionResult PutBook(UpdateBookDto updateBookDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

    }
}
