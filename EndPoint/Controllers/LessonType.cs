using Application.ServiceInterfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [ApiController]
    // [ApiVersion("1.0")]
    // [Route("[controller]/v{version:ApiVersion}")]
    [Route("[controller]")]
    public class LessonType : Controller
    {
        private readonly ILogger<User> _logger;
        private readonly ILessonTypeService _lessonTypeService;

        public LessonType(ILogger<User> logger, ILessonTypeService lessonTypeService)
        {
            _logger = logger;
            this._lessonTypeService = lessonTypeService;
        }

        [HttpPost]
        public async Task<DbProgressResultMessageViewModel> AddLessonType(AddLessonTypeViewModel vModel)
        {
            var result = await _lessonTypeService.AddLessonType(vModel);
            return result;
        }

    }
}
