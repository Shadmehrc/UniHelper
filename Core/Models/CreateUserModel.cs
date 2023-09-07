using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudyFieldId { get; set; }
        public int RoleId { get; set; }

    }
}
