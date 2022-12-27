using BookAplikation.Models;
using BookAplikation.Models.DTO;

namespace BookAplikation.Services
{
    public class LibraryBookAdapter : ILibraryBookAdapter
    {
        public GetLibraryBookDto Adapt(LibraryBook libraryBook)
        {
            List<LibraryBookUserBookDto> libraryBookUserHistory = null;
            if (libraryBook.UserBooks != null)
            {
                libraryBookUserHistory = libraryBook.UserBooks
                .Select(userBook => Adapt(userBook))
                .ToList();
            };

            return new GetLibraryBookDto()
            {
                Id = libraryBook.Id,
                BookISBN = libraryBook.BookISBN,
                BookTitle = libraryBook.Book.Title,
                BookAuthor = libraryBook.Book.Author,
                BookCoverType = libraryBook.Book.ECoverType.ToString(),
                BookPublishYear = libraryBook.Book.PublishYear.ToString(),
                IsTaken = libraryBook.IsTaken,
                LibraryBookUserHistory = libraryBookUserHistory
            };
        }

        public List<GetLibraryBookDto> Adapt(IEnumerable<LibraryBook> libraryBooks)
        {
            List<GetLibraryBookDto> result = new List<GetLibraryBookDto>();
            foreach (var libraryBook in libraryBooks)
                result.Add(Adapt(libraryBook));
            return result;
        }

        public LibraryBookUserBookDto Adapt(UserBook userBook)
        {
            return new LibraryBookUserBookDto()
            {
                Name = userBook.User.FullName,
                BookTaken = userBook.BookTaken,
                BookReturned = userBook.BookReturned
            };
        }


        public LibraryBook Adapt(string isbn, Book book)
        {
            return new LibraryBook()
            {
                BookISBN = isbn,
                Book = book,
                IsTaken = false,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
        }
    }
}
