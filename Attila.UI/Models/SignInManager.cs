using Attila.Application.Interfaces;
using Attila.Application.Login.Queries;
using Attila.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class SignInManager : ISignInManager
    {
        private readonly IMediator mediator;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IPasswordHasher passwordHasher;
        public SignInManager(IMediator mediator,
       IHttpContextAccessor contextAccessor,
       IPasswordHasher passwordHasher)
        {
            this.mediator = mediator;
            this.contextAccessor = contextAccessor;
            this.passwordHasher = passwordHasher;

        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password)
        {
            try
            {
                var _l = await mediator.Send(new VerifyUserLoginQuery { Username = userName });


                if (_l == null)
                {
                    throw new Exception("Invalid username or password");
                }

                if (!passwordHasher.IsPasswordVerified(_l.Salt, _l.Password, password))
                {
                    throw new Exception("invalid username or password");
                }

                return await SignInAsync(userName);
            }
            catch (Exception ex)
            {
                var _result = SignInResult.Failed;
                _result.Message = ex.Message;

                return _result;
            }
        }

        public async Task<SignInResult> SignInAsync(string userName)
        {
            try
            {
                var _user = await mediator.Send(new GetUserDetailsQuery { Username = userName });

                Guid _sessionUID = Guid.NewGuid();

                var _claims = new List<Claim>
                {
                //new Claim(ClaimTypes.NameIdentifier, _user.UID.ToString(), ClaimValueTypes.String),
                new Claim(ClaimTypes.Name, _user.Name, ClaimValueTypes.String),
                new Claim(ClaimTypes.Sid, _sessionUID.ToString(), ClaimValueTypes.String),
                new Claim(ClaimTypes.UserData,  JsonSerializer.Serialize(_user), ClaimValueTypes.String)
                };
                _claims.Add(new Claim(ClaimTypes.Role, _user.Role.ToString(), ClaimValueTypes.String));


                var _identity = new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var _principal = new ClaimsPrincipal(_identity);

                await contextAccessor.HttpContext.SignInAsync(_principal);

                return SignInResult.Success;
            }
            catch (Exception)
            {

                return SignInResult.Failed;
            }
        }

        public Task SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
