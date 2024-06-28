namespace MusicSharingPlatform.DTO
{
    public class UpdateSongRequestDto
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string FilePath { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
