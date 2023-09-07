using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ViewModels;
using Application.RepositoryInterfaces;

namespace Application.Services
{
    public class LessonTypeService: ILessonTypeService
    {
        private readonly ILessonTypeRepository _lessonTypeRepository;

        public LessonTypeService(ILessonTypeRepository lessonTypeRepository)
        {
            _lessonTypeRepository = lessonTypeRepository;
        }
        public async Task<DbProgressResultMessageViewModel> AddLessonType(AddLessonTypeViewModel vModel)
        {
            try
            {
                var result = await _lessonTypeRepository.AddLessonType(vModel);
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
