using BookAplikation.Helpers.IHelpers;
using BookAplikation.Models;
using BookAplikation.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatsController : ControllerBase
    {
        private readonly IUserBookRepository _userBookRepo;
        private readonly IStatsHelper _statsHelper;

        public UserStatsController(IUserBookRepository userBookRepo, IStatsHelper statsHelper)
        {
            _userBookRepo = userBookRepo;
            _statsHelper = statsHelper;
        }

        [HttpGet("FavoriteAuthors")] // 
        public ActionResult<IOrderedEnumerable<IGrouping<string, UserBook>>?> /*ActionResult<List<FavoriteAuthorDto>>*/ GetFavoriteAutors(int id)
        {
            var userBooks = _userBookRepo.GetAll(ub => ub.UserId == id);
            var favoriteAuthors = _statsHelper.GetFavoriteAutorsForUser(id, userBooks);
            return Ok(favoriteAuthors);
        }
    }
}
