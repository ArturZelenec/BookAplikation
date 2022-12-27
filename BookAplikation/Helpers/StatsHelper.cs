using BookAplikation.Helpers.IHelpers;
using BookAplikation.Models;
using BookAplikation.Models.DTO.UsersStatsDto;

namespace BookAplikation.Helpers
{
    public class StatsHelper : IStatsHelper
    {
        public List<FavoriteAuthorDto> GetFavoriteAutorsForUser(int id, List<UserBook> allBooks)
        {
            var favoriteAuthors = new List<FavoriteAuthorDto>();

            var groupByAuthor = from book in allBooks
                                group book by book.LibraryBook.Book.Author into newBookGroup
                                orderby newBookGroup.Key
                                select newBookGroup;

            foreach (var item in groupByAuthor)
            {

            }






            return favoriteAuthors;
        }
    }
}
