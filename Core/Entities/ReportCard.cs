using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReportCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChartId { get; set; }
        public int Score { get; set; }
        public bool PassStatue { get; set; }
    }
}
