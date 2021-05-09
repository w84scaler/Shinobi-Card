using System.ComponentModel.DataAnnotations;

namespace server.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        public string Nickname { get; set; }

        [Required]
        [StringLength(12,MinimumLength = 4)]
        public string Password { get; set; }
    }
}