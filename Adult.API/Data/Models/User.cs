using Microsoft.AspNetCore.Identity;

namespace Adult.API.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
