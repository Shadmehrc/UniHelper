using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface  IUserRepository
    {
        public Task<DbProgressResultMessageModel> CreateUser(CreateUserModel model);
        public Task<List<GetUserInformationModel>> GetUserInformation(int Id);
    }
}
