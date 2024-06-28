using AutoMapper;
using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;
using MusicSharingPlatform.Repository;

namespace MusicSharingPlatform.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;   
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper )
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }
        Task IUserService.DeleteUser()
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IUserService.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

       public async Task<List<SearchUserResponseDto>> SearchUserBySearchText(SearchUserRequestDto requestDto)
        {
            var userList = await _userRepository.SearchUserBySearchText(requestDto);
            var returnLİst = _mapper.Map<List<SearchUserResponseDto>>(userList);
            return returnLİst;
        }

        Task IUserService.UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
