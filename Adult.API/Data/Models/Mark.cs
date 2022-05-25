namespace Adult.API.Data.Models
{
    public class Mark
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SubjectUserId { get; set; }
        public DateTime Time { get; set; }
        public bool Liked { get; set; }
        public User User { get; set; }
        public User SubjectUser { get; set; }
    }
}
