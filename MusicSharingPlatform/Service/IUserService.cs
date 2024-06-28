using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;

namespace MusicSharingPlatform.Service
{
    public interface IUserService
    {
        Task DeleteUser();
        Task UpdateUser();
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();
        Task<List<SearchUserResponseDto>> SearchUserBySearchText(SearchUserRequestDto requestDto);

    }
}
