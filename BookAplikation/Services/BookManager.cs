using BookAplikation.Data;
using BookAplikation.Models.DTO;
using BookAplikation.Repository.IRepository;

namespace BookAplikation.Services
{
    public class BookManager : IBookManager 
    {
        private readonly IBookWrapper _wrapper;
        private readonly IBookSet _context;

        public BookManager(IBookWrapper wrapper, IBookSet context)
        {
            _wrapper = wrapper;
            _context = context;
        }

        public List<GetBookDto> Get()
        {
            var sarasas = _context.Books;
            var dto = sarasas.Select(s => _wrapper.Bind(s)).ToList();
            return dto;
        }
    }
}
