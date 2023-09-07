using Application.ServiceInterfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [ApiController]
   // [ApiVersion("1.0")]
   // [Route("[controller]/v{version:ApiVersion}")]
    [Route("[controller]")]
    public class User : Controller
    {
        private readonly ILogger<User> _logger;
        private readonly IUserService _userService;

        public User(ILogger<User> logger, IUserService userService)
        {
            _logger = logger;
            this._userService = userService;
        }

        [HttpGet]
        public async Task<List<GetUserInformationModel>> GetUserInformation(int Id)
        {
            var result = await _userService.GetUserInformation(Id);
            return result;
        }
        [HttpPost]
        public async Task<DbProgressResultMessageViewModel> CreateUser(CreateUserViewModel vModel)
        {
            var result = await _userService.CreateUser(vModel);
            return result;
        }
    }
}