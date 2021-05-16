namespace server.DTOs
{
    public class GamerDTO
    {
        public int Id { get; set; }
        public string UserName {get; set;}
        public string Nickname { get; set; }
        public bool Banned { get; set; }
        public int WinCount { get; set; }
        public int GameCount { get; set; }
    }
}