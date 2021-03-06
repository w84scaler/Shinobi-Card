using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using server.DTOs;
using server.Entities;
using server.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ICardRepository _cardRepsitory;
        private readonly ICloudinaryService _cloudinaryService;
        public AdminController(UserManager<User> userManager, ICardRepository cardRepsitory, ICloudinaryService cloudinaryService, IMapper mapper)
        {
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _cardRepsitory = cardRepsitory;
            _userManager = userManager;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("gamer")]
        public async Task<ActionResult<IEnumerable<GamerDTO>>> GetGamers()
        {
            var gamers = await _userManager.GetUsersInRoleAsync("Gamer");
            return Ok(gamers.AsQueryable().ProjectTo<GamerDTO>(_mapper.ConfigurationProvider));
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("gamer/ban/{GamerId}")]
        public async Task<ActionResult> SwitchGamerBan(string GamerId)
        {
            var gamer = await _userManager.FindByIdAsync(GamerId);
            gamer.Banned = !gamer.Banned;
            await _userManager.UpdateAsync(gamer);
            return Ok();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("card/add")]
        public async Task<ActionResult> AddCard([FromForm] AddCardDTO cardInfo)
        {
            var imageResult = await _cloudinaryService.AddImageAsync(cardInfo.IconFile);

            if (imageResult.Error != null)
                return BadRequest(imageResult.Error.Message);

            var card = _mapper.Map<Card>(cardInfo);
            
            card.Icon = new Icon
            {
                URL = imageResult.SecureUrl.AbsoluteUri,
                PublicId = imageResult.PublicId
            };

            _cardRepsitory.AddCardAsync(card);
            
            if (!(await _cardRepsitory.Complete()))
                return BadRequest("Failed while adding card");

            return Ok();
        }
    }
}
