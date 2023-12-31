﻿using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface ILessonTypeRepository
    {
        public Task<DbProgressResultMessageModel> AddLessonType(AddLessonTypeModel model);

    }
}
