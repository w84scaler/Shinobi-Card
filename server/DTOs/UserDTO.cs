namespace server.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Nickname { get; set; }
        public bool Banned { get; set; }
        public int WinCount { get; set; }
        public int GameCount { get; set; }
    }
}