using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using server.DTOs;
using server.Entities;
using server.Helpers;

namespace server.Interfaces
{
    public interface ICardRepository
    {
        Task<bool> Complete();
        Task<IEnumerable<Card>> GetCardsAsync();
        void AddCardAsync(Card card);


        //void Update(Card card);

        //Task<User> GetUserByIdAsync(int id);

        //Task<User> GetUserByUserNameAsync(string name);

        //Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

        //Task<MemberDto> GetMemberAsync(string name, bool isCurrentUser);

        //Task<string> GetUserGender(string username);

        //Task<User> getUserByPhotoId(int photoId);
    }
}