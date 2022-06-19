using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Auth;
using Domain.Entities;
using Domain.Repository;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services.Auth
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;
        private TokenConfiguration _tokenConfiguration;
        private IConfiguration _configuration { get; }
        public SigningConfiguration _signingConfiguration;
        public LoginService(IUserRepository userRepository, TokenConfiguration tokenConfiguration, IConfiguration configuration, SigningConfiguration signingConfiguration)
        {
            _userRepository = userRepository;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
            _signingConfiguration = signingConfiguration;
        }

        public async Task<object> FindByEmail(string email)
        {
            var user = await _userRepository.FindByEmail(email);
            if (user == null) return new { authenticated = false, message ="falha ao tentar autenticar" };
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(email),
                new []
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, email)
                }
            );

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
            var handler = new JwtSecurityTokenHandler();
            string token = CreateToken(identity, createDate, expirationDate, handler);
            return SuccessObject(createDate, expirationDate, token, user);
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
        
        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Email,
                name = user.Name,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}