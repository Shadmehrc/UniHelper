using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class AddLessonViewModel
    {
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int LessonTypeId { get; set; }

    }
}
