using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class LessonTypeRepository : ILessonTypeRepository
    {
        private readonly string? _connectionString;

        public LessonTypeRepository(IConfiguration configuration)
        {
            _connectionString = configuration["connection"];
        }

        public async Task<DbProgressResultMessageModel> AddLessonType(AddLessonTypeModel model)
        {
            var result = new DbProgressResultMessageModel();
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await using (var comm = new SqlCommand("[dbo].[AddLessonType]", conn))
                {
                    comm.CommandTimeout = int.MaxValue;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Name", model.Name);

                    var reader = await comm.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (reader);
                        }
                    }
                }

                return result;
            }
        }
    }

}
