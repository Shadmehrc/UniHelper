using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AddLessonTypeModel
    {
        public string Name{ get; set; }
        public static implicit operator AddLessonTypeModel(AddLessonTypeViewModel VModel)
        {
            return new AddLessonTypeModel()
            {
                Name = VModel.Name,
            };
        }
    }
}
