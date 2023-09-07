using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string FullName{ get; set; }
        public int StudyFieldId { get; set; }
        public int UniversityId { get; set; }
        protected byte IsDeleted { get; set; }
        protected DateTime CreateDate { get; set; }
        protected DateTime UpdateDate { get; set; }
    }
}
