using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using AutoMapper;

using server.DTOs;
using server.Extensions;
using server.Entities;
using server.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;

        public CardController(IMapper mapper, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDTO>>> GetCards()
        {
            var cards = await _cardRepository.GetCardsAsync();
            var cardsDTO = cards.Select(c => _mapper.Map<CardDTO>(c));
            return Ok(cardsDTO);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<CardDTO>>> GetUserCards()
        {
            var cards = await _cardRepository.GetUserCards(User.GetUserId());
            var cardsDTO = cards.Select(c => _mapper.Map<CardDTO>(c));
            return Ok(cardsDTO);
        }
    }
}
