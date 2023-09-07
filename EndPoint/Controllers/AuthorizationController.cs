using Application.Interfaces;
using Domain.Models;
using Domain.Response;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
   // [ApiVersion("1.0")]
    [Route("[controller]/v{version:ApiVersion}")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Response<bool>> ValidateAsync([FromBody] UserSignUpViewModel signUpModel)
        {
            var result = await _authorizationService.RegisterNewUser(signUpModel);
            return !result
                ? Response<bool>.Failure(new[] { "Username Exist" })
                : Response<bool>.Success(true);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<Response<TokenResponseModel>> ValidateAsync([FromBody] UserLoginModel loginModel)
        {
            var token = await _authorizationService.ValidateLogin(loginModel);
            return token is null
                ? Response<TokenResponseModel>.Failure(new[] { "username And password does not match.please try again" })
                : Response<TokenResponseModel>.Success(token);
        }
    }
}