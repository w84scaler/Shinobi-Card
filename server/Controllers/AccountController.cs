using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using server.DTOs;
using server.Entities;
using server.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _sinIngManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager, SignInManager<User> sinIngManager, IMapper mapper, ITokenService tokenService)
        {
            _sinIngManager = sinIngManager;
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.UserName))
                return BadRequest("User name is taken");

            var user = _mapper.Map<User>(registerDTO);

            if (user.Nickname == null)
            {
                user.Nickname = user.UserName;
            }

            user.UserName = registerDTO.UserName.ToLower();

            var res = await _userManager.CreateAsync(user, registerDTO.Password);

            if(!res.Succeeded)
                return BadRequest();

            var roleResult = await _userManager.AddToRoleAsync(user, "Gamer");

            if(!roleResult.Succeeded)
                return BadRequest();

            return new UserDTO
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Banned = user.Banned,
                WinCount = user.WinCount,
                Nickname = user.Nickname
            };
        }

        private async Task<bool> UserExists(string userName)
        {
            return await _userManager.Users.AnyAsync(user => user.UserName == userName.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(user => user.UserName == loginDTO.UserName.ToLower()); 

            if (user == null)
                return Unauthorized("Invalig login");

            var res = await _sinIngManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if(!res.Succeeded)
                return Unauthorized();

            return new UserDTO
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Banned = user.Banned,
                WinCount = user.WinCount,
                Nickname = user.Nickname
            };
        }
    }
}
