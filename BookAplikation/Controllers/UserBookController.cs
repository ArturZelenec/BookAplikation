using BookAplikation.Data;
using BookAplikation.Helpers.IHelpers;
using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Repository.IRepository;
using BookAplikation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookController : ControllerBase
    {
        private readonly BookContext _db;
        private readonly IUserBookRepository _userBookRepo;
        private readonly ILibraryBookRepository _libraryBookRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUserBookAdapter _adapter;
        private readonly ILibraryHelper _libraryHelper;

        public UserBookController(BookContext db,
                                  IUserBookRepository userBookRepo,
                                  IUserBookAdapter adapter,
                                  ILibraryBookRepository libraryBookRepo,
                                  IUserRepository userRepo,
                                  ILibraryHelper libraryHelper)
        {
            _db = db;
            _userBookRepo = userBookRepo;
            _adapter = adapter;
            _libraryBookRepo = libraryBookRepo;
            _userRepo = userRepo;
            _libraryHelper = libraryHelper;
        }

        /// <summary>
        /// Grazina visa imtu knygu istorija
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public ActionResult<List<GetUserBookDto>> GetAction()
        {
            var getUserBookDtoList = _userBookRepo.GetAll()
                                                  .Select(userBooks => _adapter.Adapt(userBooks))
                                                  .ToList();
            return getUserBookDtoList;
        }

        /// <summary>
        /// Grazina vieno kliento imtu knygu istorija
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id:int}")]
        public ActionResult<GetUserBookDto> GetUserBookById(int id)
        {
            var userBook = _userBookRepo.Get(ub => ub.UserId == id);
            return _adapter.Adapt(userBook);
        }

        /// <summary>
        /// Paimti knyga is bibliotekos
        /// </summary>
        /// <param name="createUserBookDto">Parametrai: kas ima knyga ir kokia ima knyga</param>
        /// <returns></returns>
        [HttpPost("TakeLibraryBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<GetUserBookDto> TakeLibraryBook(CreateUserBookDto createUserBookDto)
        {
            if (createUserBookDto == null) return BadRequest();

            var libraryBook = _libraryBookRepo.Get(b => b.Id == createUserBookDto.LibraryBookId);
            if (libraryBook == null) return NotFound("libraryBook = null");

            var canThisBookBeTaken = _libraryHelper.CanThisBookBeTaken(libraryBook);
            if (!canThisBookBeTaken.Answer) return NotFound(canThisBookBeTaken.Message);

            var getUserDto = _userRepo.Get(b => b.Id == createUserBookDto.UserId);
            if (getUserDto == null) return NotFound("getUserDto = null");

            var canThisUserTakeABook = _libraryHelper.CanThisUserTakeABook(getUserDto);
            if (!canThisUserTakeABook.Answer) return NotFound(canThisUserTakeABook.Message);

            UserBook newUserBook = _adapter.Adapt(getUserDto, libraryBook);
            _userBookRepo.Create(newUserBook);

            libraryBook.IsTaken = true;
            _libraryBookRepo.Update(libraryBook);

            _userRepo.UpdateTakenLibraryBooks(getUserDto.UserId, +1);

            GetUserBookDto getUserBookDto = _adapter.Adapt(newUserBook);

            return CreatedAtAction(nameof(GetUserBookById), new { id = getUserBookDto.UserId }, getUserBookDto);
        }

        /// <summary>
        /// Graziname knyga i biblioteka
        /// </summary>
        /// <param name="id">bibliotekos knygos id</param>
        /// <returns></returns>
        [HttpPut("ReturnLibraryBook/{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult ReturnLibraryBookById(int id)
        {
            var userBook = _userBookRepo.Get(b => b.Id == id);
            if (userBook == null) return NotFound("userBook == null");

            var libraryBook = _libraryBookRepo.Get(b => b.Id == userBook.LibraryBookId);
            if (libraryBook == null) return NotFound("libraryBook == null");

            userBook.BookReturned = DateTime.Now;
            _userBookRepo.Update(userBook);

            libraryBook.IsTaken = false;
            _libraryBookRepo.Update(libraryBook);

            _userRepo.UpdateTakenLibraryBooks(userBook.UserId, -1);

            return NoContent();
        }

    }
}
