using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string? _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration["connection"];
        }

        public async Task<DbProgressResultMessageModel> CreateUser(CreateUserModel model)
        {
            var result = new DbProgressResultMessageModel();
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await using (var comm = new SqlCommand("[dbo].[CreateUser]", conn))
                {
                    comm.CommandTimeout = int.MaxValue;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@UserName", model.UserName);
                    comm.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                    comm.Parameters.AddWithValue("@HashedPassword", model.HashedPassword);
                    comm.Parameters.AddWithValue("@FirstName", model.FirstName);
                    comm.Parameters.AddWithValue("@LastName", model.LastName);
                    comm.Parameters.AddWithValue("@RoleId", model.RoleId);
                    comm.Parameters.AddWithValue("@StudyFieldId", model.StudyFieldId);


                    var reader = await comm.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result=(reader);
                        }
                    }
                }
                return result;
            }
        }

        public async Task<List<GetUserInformationModel>> GetUserInformation(int Id)
        {
            var result = new List<GetUserInformationModel>();
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await using (var comm = new SqlCommand("[dbo].[GetUserInformation]", conn))
                {
                    comm.CommandTimeout = int.MaxValue;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Id", Id);

                    var reader = await comm.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(reader);
                        }
                    }
                }
                return new List<GetUserInformationModel>();
            }
        }
    }
}
    

