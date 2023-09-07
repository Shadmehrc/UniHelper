using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface ILessonService
    {
        public Task<DbProgressResultMessageViewModel> AddLesson(AddLessonViewModel vModel);

    }
}
