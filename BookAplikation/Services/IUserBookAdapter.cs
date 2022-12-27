using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Models.DTO.UserDto;

namespace BookAplikation.Services
{
    public interface IUserBookAdapter
    {
        public UserBook Adapt(GetUserDto user, LibraryBook libraryBook);
        public GetUserBookDto Adapt(UserBook userBook);
    }
}
