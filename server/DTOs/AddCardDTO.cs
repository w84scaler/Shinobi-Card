using Microsoft.AspNetCore.Http;

namespace server.DTOs
{
    public class AddCardDTO
    {
        public string Name { get; set; }
        public int Genjutsu { get; set; }
        public int Ninjutsu { get; set; }
        public int Taijutsu { get; set; }
        public IFormFile IconFile { get; set; }
    }
}