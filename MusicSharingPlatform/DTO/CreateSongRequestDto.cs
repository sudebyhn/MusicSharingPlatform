namespace MusicSharingPlatform.DTO
{
    public class CreateSongRequestDto
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
