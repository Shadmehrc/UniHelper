using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.ViewModels
{
    public class CreateUserViewModel
    {
        public string UserName{ get; set; }
        public string EmailAddress{ get; set; }
        public string Password{ get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public int StudyFieldId{ get; set; }
        public int RoleId{ get; set; }

        public static implicit operator CreateUserModel(CreateUserViewModel VModel)
        {
            return new CreateUserModel()
            {
                UserName = VModel.UserName,
                EmailAddress = VModel.EmailAddress,
                HashedPassword = VModel.Password,
                FirstName = VModel.FirstName,
                LastName = VModel.LastName,
                StudyFieldId = VModel.StudyFieldId,
                RoleId = VModel.RoleId,
            };
        }

    }
}
