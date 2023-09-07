using System.Security.Claims;
using System.Text;
using Application.Common;
using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Domain.Entities;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using Application.RepositoryInterfaces;
using Domain.ViewModels;

namespace Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersDataAccess _usersDataAccess;

        public AuthorizationService(IConfiguration configuration, IUsersDataAccess usersDataAccess)
        {
            _configuration = configuration;
            _usersDataAccess = usersDataAccess;
        }

        public async Task<bool> RegisterNewUser(UserSignUpViewModel signUpModel)
        {
            var user = await _usersDataAccess.GetUser(signUpModel.UserName);
            if (user is not null)
                return false;
            var hashedPassword = SecurityHelper.CreateSHA512(signUpModel.Password);
            var userModel = signUpModel.Adapt<UserSignUpModel>();
            userModel.Password = hashedPassword;
            var result = await _usersDataAccess.AddUser(userModel);
            return result;
        }

        public async Task<TokenResponseModel?> ValidateLogin(UserLoginModel loginModel)
        {
            var hashedPassword = SecurityHelper.CreateSHA512(loginModel.Password);
            var user = await _usersDataAccess.ValidateUser(loginModel.UserName, hashedPassword);
            if (user is null)
                return null;
            var token = GenerateToken(loginModel);
            var result = new TokenResponseModel()
            {
                Token = "Bearer " + token,
                ValidUntil = DateTime.Now.AddMinutes(double.Parse(_configuration["JWtConfig:ValidityTimeMinutes"]))
            };
            return result;
        }

        public string GenerateToken(UserLoginModel loginModel)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.UserName ?? throw new InvalidOperationException()),
            };
            var key = _configuration["JWtConfig:Key"];
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWtConfig:issuer"],
                audience: _configuration["JWtConfig:audience"],
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWtConfig:ValidityTimeMinutes"]))
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}