using Microsoft.AspNetCore.Http;

namespace OlexShop.Core.Domain.Entities
{
    public class UserAuthentication
    {
        public int UsernameId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public IFormFile Images { get; set; }
    }
}
