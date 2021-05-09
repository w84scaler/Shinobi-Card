using System.ComponentModel.DataAnnotations;

namespace server.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { set; get; } 
    }
}