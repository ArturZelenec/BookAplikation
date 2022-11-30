using BookAplikation.Data;
using BookAplikation.Models;
using BookAplikation.Models.DTO;

namespace BookAplikation.Services
{
    public class BookWrapper : IBookWrapper
    {
       public GetBookDto Bind(Book book)
        {
            return new GetBookDto
            {
                Id = book.Id,
                PavadinimasIrAutorius = $"{book.Author} {book.Title}",
                LeidybosMetai = book.PublishYear
            };
        }

        public Book Bind(CreateBookDto book)
        {
            return new Book
            {
                Title = book.Pavadinimas,
                Author = book.Autorius,
                PublishYear = book.Isleista.Year,
                CoverType = (ECoverType)Enum.Parse(typeof(ECoverType), book.KnygosTypas),
            };
        }

        public Book Bind(UpdateBookDto book)
        {
            return new Book
            {
                Id = book.Id,
                Title = book.Pavadinimas,
                Author = book.Autorius,
                PublishYear = book.Isleista.Year,
                CoverType = (ECoverType)Enum.Parse(typeof(ECoverType), book.KnygosTipas),

            };
        }
    }
}
