using Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DbProgressResultMessageViewModel
    {
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }

        public static implicit operator DbProgressResultMessageViewModel(DbProgressResultMessageModel model)
        {
            return new DbProgressResultMessageViewModel()
            {
                IsSuccess = model.IsSuccess,
                ResultMessage = model.ResultMessage,
            };
        }
    }
}
