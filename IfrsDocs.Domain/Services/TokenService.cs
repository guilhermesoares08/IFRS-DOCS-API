using AutoMapper;
using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IfrsDocs.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config,
                            IUserService userService,
                            IMapper mapper)
        {
            _config = config;
            _userService = userService;
            _mapper = mapper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(UserDto userDto)
        {
            var user = _userService.GetUserByLogin(userDto.Login);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            var userSearch = _userService.GetUserById(user.Id);

            claims.Add(new Claim(ClaimTypes.Role, userSearch.Role.Description));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
