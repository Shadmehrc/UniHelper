using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domain.Models
{
    public class GetUserInformationModel
    {
        public string NickName{ get; set; }
        public string Email{ get; set; }
        public static implicit operator GetUserInformationModel(SqlDataReader reader)
        {
            return new GetUserInformationModel()
            {
                //Id = Convert.ToInt32(reader[nameof(Id)]),
                //UserName = reader[nameof(UserName)].ToString(),
                //CreateDate = Convert.ToDateTime(reader[nameof(CreateDate)]),
                NickName = reader[nameof(NickName)].ToString(),
                Email = reader[nameof(Email)].ToString(),
            };
        }
    }
}
