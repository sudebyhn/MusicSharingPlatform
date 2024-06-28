namespace MusicSharingPlatform.Models
{
    public class User
    {
        public int UserId { get; set; } 
        public string Username { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; } 
        public string Password { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }

}

