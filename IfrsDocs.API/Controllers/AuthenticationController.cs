using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserService service,
            IMapper mapper,
            ITokenService tokenService)
        {
            _service = service;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            try
            {
                User usr = _service.ValidateUser(userLogin.Login, userLogin.Password);
                if(usr == null) return Unauthorized();

                var retUser = _mapper.Map<UserDto>(usr);
                if (retUser != null)
                {
                    return Ok(new
                    {
                        userName = retUser.Login,
                        token = _tokenService.CreateToken(retUser)
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("UserByLogin/{login}")]
        [AllowAnonymous]
        public IActionResult GetUserByLogin(string login)
        {
            try
            {
                User usr = _service.GetUserByLogin(login);
                var retUser = _mapper.Map<UserDto>(usr);

                return Ok(retUser);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _service.Add(user);
                var userToReturn = _mapper.Map<UserDto>(user);
                if (await _service.SaveChangesAsync())
                {
                    return Created("GetUser", userToReturn);
                }

                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
    }
}
