using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface ILessonRepository
    {
        public Task<DbProgressResultMessageModel> AddLesson(AddLessonModel model);

    }
}
