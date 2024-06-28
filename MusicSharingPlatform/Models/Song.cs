namespace MusicSharingPlatform.Models
{
    public class Song
    {
        public int SongId { get; set; } 
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string FilePath { get; set; }
        public TimeSpan Duration { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; } 
    }
}
