using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using BackendApi.Model;
using BackendApi.Repositories;
using BackendApi.Security.Configurations;

namespace BackendApi.Business.Implementations
{
    public class LoginBusinessImpl : ILoginBusiness
    {
        private readonly IUserRepository _repository;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfiguration;

        public LoginBusinessImpl(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfiguration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
        }

        object ILoginBusiness.FindByLogin(User user)
        {
            bool credentialsIsValid = false;

            if (user != null && !String.IsNullOrEmpty(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);

                if (baseUser != null && baseUser.Password == user.Password)
                {
                    credentialsIsValid = true;
                }
            }

            if (credentialsIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                    }
                    );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SucessObjetct(createDate, expirationDate, token);
            }
            return ExceptionObject();
    }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return token;
        }

        private object SucessObjetct(DateTime createDate, DateTime expirationDate, String token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                message = "OK"
            };
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "Falha na autenticação"
            };
        }

    }
}
