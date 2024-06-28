using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicSharingPlatform.Data;
using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;
using MusicSharingPlatform.Repository;

namespace MusicSharingPlatform.Service
{
    // tasarım desenidir
    public class SongService : ISongService
    {
        private readonly DataContext _context;  //readonly?
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper; 
        public SongService(DataContext context, ISongRepository songRepository, IMapper mapper) { //tekrar tanımladık public ama nşye ?
            _context = context;
            _songRepository = songRepository;
            _mapper = mapper;
        
        }
      public async Task CreateSong(CreateSongRequestDto requestDto)
        {
            var newSong = new Song
            {
                Title = requestDto.Title,
                Artist = requestDto.Artist,
                FilePath = requestDto.FilePath,
                UserId = requestDto.UserId,
                
            };

            await _songRepository.AddSong(newSong);

 //Gelen isteğe (CreateSongRequestDto) göre bir şarkı nesnesi oluşturur
 //ve bu nesneyi veritabanına eklemek için ISongRepository üzerinden bir metod çağırır.

        }

        public async Task DeleteSong(DeleteSongRequestDto requestDto)
        {
            var songToDelete = await _songRepository.GetSongById(requestDto.SongId);
            if (songToDelete != null && songToDelete.UserId == requestDto.UserId)
            {
                await _songRepository.DeleteSongById(requestDto.SongId);
            }
            else
            {
                throw new Exception("Song not found or you don't have permission to delete this song.");
            }

        }
        //_songRepository.DeleteSongById(requestDto.SongId);
        //_songRepository üzerinde DeleteSongById metodunu çağırarak bir şarkıyı veritabanından silmeyi gerçekleştirir
        //DeleteSongById: ISongRepository arayüzünde tanımlı bir metoddur VE songrepository de açıklanmıştır kodun amacı
        public async Task<List<Song>> GetSong()
        {
            return await _songRepository.GetAllSongs();
        }

        public async Task<Song> GetSongById(int songId)
        {
            return await _songRepository.GetSongById(songId);
        }

        public async Task<List<Song>>GetSongByUserId(int userId)
        {
            return await _songRepository.GetSongsByUserId(userId);
        }

        public async Task<List<GetSearchResponseDto>> Search(SearchRequestDto searchRequestDto)  //GetSearchResponseDto database den ,SearchRequestDto kullanıcıdan gelen
        {
            {
                var searchText = searchRequestDto.Title ?? searchRequestDto.Artist ?? searchRequestDto.Username ?? searchRequestDto.Name ?? searchRequestDto.SurName;

                var songs = await _context.Songs
                   .Where(s => s.Title.Contains(searchText) || s.Artist.Contains(searchText))
                   .ToListAsync();

                var users = await _context.Users
                    .Where(u => u.Username.Contains(searchText) || u.Name.Contains(searchText) || u.SurName.Contains(searchText))
                    .ToListAsync();

                var result = new List<GetSearchResponseDto>();

                foreach (var song in songs)
                {
                    result.Add(_mapper.Map<GetSearchResponseDto>(song));
                }

                foreach (var user in users)
                {
                    result.Add(_mapper.Map<GetSearchResponseDto>(user));
                }

                return result;
            }

        }

       public async Task UpdateSong(UpdateSongRequestDto requestDto)
        {
            var songToBeUpdated = await _songRepository.GetSongById(requestDto.SongId);
            if (songToBeUpdated != null)
            {
                
                songToBeUpdated.Title = requestDto.Title;
                songToBeUpdated.Artist = requestDto.Artist;
                songToBeUpdated.Genre = requestDto.Genre;
                songToBeUpdated.FilePath = requestDto.FilePath;
                songToBeUpdated.Duration = requestDto.Duration;


                await _songRepository.UpdateSong(songToBeUpdated);
            }
            else
            {
                throw new Exception("Song not found.");
            }
        }

       public async Task<List<SearchSongResponseDto>> SearchSongBySerachText(SearchSongRequestDto requestDto)
        {
            var songList = await _songRepository.SearchSongBySearchText(requestDto);
            var returnList = _mapper.Map<List<SearchSongResponseDto>>(songList);
            return returnList;
        }
    }

}
