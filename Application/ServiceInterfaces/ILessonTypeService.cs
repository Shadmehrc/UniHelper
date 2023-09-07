using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface ILessonTypeService
    {
        public Task<DbProgressResultMessageViewModel> AddLessonType(AddLessonTypeViewModel vModel);

    }
}
