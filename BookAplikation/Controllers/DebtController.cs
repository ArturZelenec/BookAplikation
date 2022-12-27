using BookAplikation.Data;
using BookAplikation.Helpers.IHelpers;
using BookAplikation.Models.DTO.DebtDto;
using BookAplikation.Repository.IRepository;
using BookAplikation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : ControllerBase
    {
        private readonly BookContext _db;
        private readonly IUserRepository _userRepo;
        private readonly ILibraryBookRepository _libraryBookRepo;
        private readonly IUserBookRepository _userBookRepo;
        private readonly IUserBookAdapter _adapter;
        private readonly IDebtHelper _debt;

        public DebtController(BookContext db, IUserBookRepository userBookRepo, IUserBookAdapter adapter, ILibraryBookRepository libraryBookRepo, IUserRepository userRepo)
        {
            _db = db;
            _userBookRepo = userBookRepo;
            _adapter = adapter;
            _libraryBookRepo = libraryBookRepo;
            _userRepo = userRepo;
        }

        /// <summary>
        /// Paskaiciuoja visas skolas, atnaujina duombaze ir grazina skolininku sarasa 
        /// </summary>
        /// <returns></returns>
        [HttpGet("CalculateAllDebts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UserDebtDto>> CalculateAllDebts()
        {
            return Ok(_debt.UpdateAndGetAllDebtForEveryone());
        }
    }
}
