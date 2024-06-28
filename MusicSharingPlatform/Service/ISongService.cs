using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;

namespace MusicSharingPlatform.Service
{
    public interface ISongService
    {
        Task CreateSong(CreateSongRequestDto requestDto);
        Task DeleteSong(DeleteSongRequestDto requestDto);
        Task UpdateSong(UpdateSongRequestDto requestDto);
        Task<List<Song>> GetSong();
        Task<List<GetSearchResponseDto>> Search(SearchRequestDto searchRequestDto);
        Task<List<Song>> GetSongByUserId(int userId);
        Task<Song> GetSongById(int songId);
        Task<List<SearchSongResponseDto>> SearchSongBySerachText(SearchSongRequestDto requestDto);

    }
}
