namespace server.DTOs
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Genjutsu { get; set; }
        public int Ninjutsu { get; set; }
        public int Taijutsu { get; set; }
        public string IconURL { get; set; }
    }
}