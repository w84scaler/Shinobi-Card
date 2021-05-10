namespace server.Entities
{
    public class Icon
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string PublicId { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
    }
}