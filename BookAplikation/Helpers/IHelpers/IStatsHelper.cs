using BookAplikation.Models;
using BookAplikation.Models.DTO.UsersStatsDto;

namespace BookAplikation.Helpers.IHelpers
{
    public interface IStatsHelper
    {
        public List<FavoriteAuthorDto> GetFavoriteAutorsForUser(int id, List<UserBook> allBooks);
    }
}
