using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace server.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}