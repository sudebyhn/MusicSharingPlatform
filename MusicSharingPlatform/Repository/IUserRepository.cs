using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;

namespace MusicSharingPlatform.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUserById(int userId);
        Task<List<User>> SearchUserBySearchText(SearchUserRequestDto requestDto);
    }
}
