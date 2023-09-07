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
    public class LessonRepository :ILessonRepository
    {
        private readonly string? _connectionString;

        public LessonRepository(IConfiguration configuration)
        {
            _connectionString = configuration["connection"];
        }
        public async Task<DbProgressResultMessageModel> AddLesson(AddLessonModel model)
        {
            var result = new DbProgressResultMessageModel();
            await using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await using (var comm = new SqlCommand("[dbo].[AddLesson]", conn))
                {
                    comm.CommandTimeout = int.MaxValue;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Name", model.Name);
                    comm.Parameters.AddWithValue("@UnitCount", model.UnitCount);
                    comm.Parameters.AddWithValue("@LessonTypeId", model.LessonTypeId);

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
