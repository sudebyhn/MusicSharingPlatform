using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MusicSharingPlatform.Data;
using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;

namespace MusicSharingPlatform.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly DataContext _context;

        public SongRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Song> GetSongById(int songId)
        {
            return await _context.Songs.FindAsync(songId);
        }

        public async Task<List<Song>> GetAllSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<List<Song>> GetSongsByUserId(int userId)
        {
            return await _context.Songs.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task AddSong(Song song)
        {
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSong(Song song)
        {
           
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSongById(int songId)
        {
            var songToDelete = await _context.Songs.FindAsync(songId);
            if (songToDelete != null)
            {
                _context.Songs.Remove(songToDelete);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<object>> Search(string searchText)
        {
            var songs = await _context.Songs
               .Where(s => s.Title.Contains(searchText) || s.Artist.Contains(searchText))
               .ToListAsync();

            var users = await _context.Users
                .Where(u => u.Username.Contains(searchText) || u.Name.Contains(searchText) || u.SurName.Contains(searchText))
                .ToListAsync();

            var result = new List<object>();
            result.AddRange(songs);
            result.AddRange(users);

            return result;
        }

        public async Task<List<Song>> SearchSongBySearchText(SearchSongRequestDto requestDto)
        {
            var querry = await _context.Songs.ToListAsync();
            return querry.Where(t=> t.Title.Contains(requestDto.Artist)).ToList();
        }
    }
}
