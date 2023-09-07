using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DbProgressResultMessageModel
    {
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }

        public static implicit operator DbProgressResultMessageModel(SqlDataReader reader)
        {
            return new DbProgressResultMessageModel()
            {
                IsSuccess = Convert.ToBoolean(reader[nameof(IsSuccess)]),
                ResultMessage = reader[nameof(ResultMessage)].ToString()
            };
        }
    }
}
