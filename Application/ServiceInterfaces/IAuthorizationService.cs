using Domain.Models;
using Domain.ViewModels;

namespace Application.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<TokenResponseModel?> ValidateLogin(UserLoginModel loginModel);
        Task<bool> RegisterNewUser(UserSignUpViewModel signUpModel);
    }
}