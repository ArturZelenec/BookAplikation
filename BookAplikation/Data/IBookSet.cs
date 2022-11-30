using BookAplikation.Models;

namespace BookAplikation.Data
{
    public interface IBookSet
    {
        List<Book> Books { get; set; }
    }
}
