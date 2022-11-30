using BookAplikation.Models;
using BookAplikation.Models.DTO;

namespace BookAplikation.Services
{
    public interface IBookWrapper
    {
        GetBookDto Bind(Book book);
        Book Bind(CreateBookDto book);
        Book Bind(UpdateBookDto book);

    }

    
}
