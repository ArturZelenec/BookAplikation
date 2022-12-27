using BookAplikation.Models;

namespace BookAplikation.Repository.IRepository
{
    public interface ILibraryBookRepository : IRepository<LibraryBook>
    {
        LibraryBook Update(LibraryBook libraryBook);
    }
}
