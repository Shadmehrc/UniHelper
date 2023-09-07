using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Domain.Models;
using Domain.ViewModels;

namespace Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DbProgressResultMessageViewModel> CreateUser(CreateUserViewModel vModel)
        {
            try
            {
                var result = await _userRepository.CreateUser(vModel);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
        }

        public async Task<List<GetUserInformationModel>> GetUserInformation(int Id)
        {
            try
            {
                var result= await _userRepository.GetUserInformation(Id);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
