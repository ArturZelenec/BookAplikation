using BookAplikation.Models;
using BookAplikation.Models.DTO;

namespace BookAplikation.Services
{
    public interface ILibraryBookAdapter
    {
        GetLibraryBookDto Adapt(LibraryBook libraryBook);
        List<GetLibraryBookDto> Adapt(IEnumerable<LibraryBook> libraryBooks);
        LibraryBook Adapt(string isbn, Book book);
    }
}
