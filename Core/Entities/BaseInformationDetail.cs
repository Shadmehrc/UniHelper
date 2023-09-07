using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseInformationDetail
    {
        public int Id{ get; set; }
        public string Detail { get; set; }
        public int BaseInformationId { get; set; }
    }
}
