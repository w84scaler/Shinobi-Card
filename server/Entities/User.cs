using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace server.Entities
{
    public class User : IdentityUser<int>
    {
        public string Nickname { get; set; }

        public bool Banned { get; set; } = false;

        public int WinCount { get; set; } = 0;

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserCard> UserCards { get; set; }
    }
}