using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using Dapper;
using Application.RepositoryInterfaces;
using Domain.Models;

namespace Infrastructure.Repository
{
    internal class UsersDataAccess: IUsersDataAccess
    {
        private readonly ILogger<IUsersDataAccess> _logger;
        private readonly string? _connectionString;

        public UsersDataAccess(IConfiguration config, ILogger<IUsersDataAccess> logger)
        {
            _connectionString = config["connection"];
            _logger = logger;
        }
        public async Task<User> GetUser(string userName)
        {
            try
            {
                await using var sqlConnection = new SqlConnection(_connectionString);
                var result = await
                    (sqlConnection.QueryFirstOrDefaultAsync<User>("User_Get",
                        new { userName },
                        commandType: CommandType.StoredProcedure));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
        
        public async Task<List<User>> ValidateUser(string userName,string password)
        {
            try
            {
                await using var sqlConnection = new SqlConnection(_connectionString);
                var result = await
                    (sqlConnection.QueryFirstOrDefaultAsync<List<User>>("User_Validate",
                        new { userName , Password = password},
                        commandType: CommandType.StoredProcedure));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task<bool> AddUser(UserSignUpModel userModel)
        {
            try
            {
                await using var sqlConnection = new SqlConnection(_connectionString);
                var res = (await sqlConnection.ExecuteAsync(sql: "User_Insert",
                    new
                    {
                        userModel.UserName,
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 240
                ));
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
