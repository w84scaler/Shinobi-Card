using System;

namespace server.Entities
{
    public class ShinobiCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Genjutsu { get; set; }
        public int Ninjutsu { get; set; }
        public int Taijutsu { get; set; }
        public int IconURL { get; set; }
    }
}
