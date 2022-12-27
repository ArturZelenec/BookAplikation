using BookAplikation.Models;

namespace BookAplikation.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Update(Book book);
    }
}
