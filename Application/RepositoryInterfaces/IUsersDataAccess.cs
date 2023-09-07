using Domain.Entities;
using Domain.Models;

namespace Application.RepositoryInterfaces;

public interface IUsersDataAccess
{
    public Task<User> GetUser(string userId);
    public Task<bool> AddUser(UserSignUpModel userModel);
    public Task<List<User>> ValidateUser(string userName, string password);
}