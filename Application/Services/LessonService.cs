using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Domain.ViewModels;

namespace Application.Services
{
    public class LessonService :ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<DbProgressResultMessageViewModel> AddLesson(AddLessonViewModel vModel)
        {
            try
            {
                var result = await _lessonRepository.AddLesson(vModel);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
