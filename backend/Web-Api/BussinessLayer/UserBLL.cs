using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class UserBLL : IUserBLL
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration config;
        public UserBLL(IUnitOfWork uow, IConfiguration config)
        {
            this.uow = uow;
            this.config = config;
        }

        //get my tokens
        public async Task<UserTokensDTO> GetMyTokens(int userId)
        {
            var user = await uow.UserRepository.GetMyTokens(userId);
            if(user != null)
            {
                var response = new UserTokensDTO();
                response.TokenCount = user.TokensAvailable;
                response.Username = user.Username;
                return response;
            }

            return null;
        }

        //Login user
        public async Task<LoginResponseDTO> LoginUser(LoginDTO user)
        {
            var result = await uow.UserRepository.Login(user.Username, user.Password);
            if (result != null)
            {
                var loginResponse = new LoginResponseDTO();
                loginResponse.Username = user.Username;
                loginResponse.Token = CreateJWT(result);
                return loginResponse;
            }
            return null;
        }

        //JWT Token Create
        private string CreateJWT(User user)
        {
            var secretKey = config.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Name,user.TokensAvailable.ToString()),
                new Claim(ClaimTypes.Name,user.UserId.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
            };

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
