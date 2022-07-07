namespace Adult.API.Identity.BLL.Configurations
{
    public class JwtConfiguration
    {
        public string Key { get; set; }
        public TimeSpan LifeTime { get; set; }
    }
}
