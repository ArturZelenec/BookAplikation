using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Models.DTO.UserDto;

namespace BookAplikation.Services
{
    public class UserBookAdapter : IUserBookAdapter
    {
        public UserBook Adapt(GetUserDto user, LibraryBook libraryBook)
        {
            return new UserBook()
            {
                UserId = user.UserId,
                LibraryBookId = libraryBook.Id,
                BookTaken = DateTime.Now,
                BookReturned = null,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
        }

        public GetUserBookDto Adapt(UserBook userBook)
        {
            return new GetUserBookDto()
            {
                Id = userBook.Id,
                UserId = userBook.UserId,
                UserFullName = userBook.User.FullName,
                LibraryBookId = userBook.LibraryBookId,
                BookISBN = userBook.LibraryBook.Book.ISBN,
                BookTitle = userBook.LibraryBook.Book.Title,
                BookAuthor = userBook.LibraryBook.Book.Author,
                BookTaken = userBook.BookTaken,
                BookReturned = userBook.BookReturned
            };
        }
    }
}
