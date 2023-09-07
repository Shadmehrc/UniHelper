using Application.ServiceInterfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [ApiController]
     [ApiVersion("1.0")]
    // [Route("[controller]/v{version:ApiVersion}")]
    [Route("[controller]")]
    public class Lesson : Controller
    {
        private readonly ILogger<User> _logger;
        private readonly ILessonService _lessonService;

        public Lesson(ILogger<User> logger, ILessonService lessonService)
        {
            _logger = logger;
            this._lessonService = lessonService;
        }

        [HttpPost]
        public async Task<DbProgressResultMessageViewModel> AddLessonType(AddLessonViewModel vModel)
        {
            var result = await _lessonService.AddLesson(vModel);
            return result;
        }

    }
}
