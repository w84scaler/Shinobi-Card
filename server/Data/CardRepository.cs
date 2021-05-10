using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using server.DTOs;
using server.Entities;
using server.Helpers;
using server.Interfaces;

namespace server.Data
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CardRepository(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<bool> Complete()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Card>> GetCardsAsync()
        {
            return await _dataContext.Cards.Include(c => c.Icon).ToListAsync<Card>();
        }

        public async void AddCardAsync(Card card)
        {
            await _dataContext.Cards.AddAsync(card);
        }
    }
}