using BookAplikation.Models.DTO;

namespace BookAplikation.Services
{
    public interface IBookManager
    {
        List<GetBookDto> Get();
    }
}
