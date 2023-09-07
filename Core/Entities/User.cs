using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public int RoleId { get; set; }
        protected byte IsDeleted { get; set; }
        protected DateTime CreateDate { get; set; }
        protected DateTime UpdateDate { get; set; }
    }
}
