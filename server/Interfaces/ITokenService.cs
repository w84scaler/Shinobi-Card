using System.Threading.Tasks;
using server.Entities;

namespace server.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}