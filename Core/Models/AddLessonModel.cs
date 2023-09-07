using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AddLessonModel
    {
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int LessonTypeId { get; set; }
        public static implicit operator AddLessonModel(AddLessonViewModel VModel)
        {
            return new AddLessonModel()
            {
                Name = VModel.Name,
                UnitCount = VModel.UnitCount,
                LessonTypeId = VModel.LessonTypeId
            };
        }
    }
}
