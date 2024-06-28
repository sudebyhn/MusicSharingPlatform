using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;

namespace MusicSharingPlatform.Repository
{
    public interface ISongRepository
    {
        Task<Song> GetSongById(int songId);
        Task<List<Song>> GetAllSongs();
        Task<List<Song>> GetSongsByUserId(int userId);
        Task AddSong(Song song);
        Task UpdateSong(Song song);
        Task DeleteSongById(int songId);
        Task<List<object>> Search(string searchText);
        Task<List<Song>> SearchSongBySearchText(SearchSongRequestDto requestDto);
    }
}
