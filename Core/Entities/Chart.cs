using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chart
    {   
        public int Id { get; set; }
        public int SemesterNumber { get; set; }
        public int LessonId { get; set; }
        public int UniversityId { get; set; }
        public int StudyFieldId { get; set; }


    }
}
