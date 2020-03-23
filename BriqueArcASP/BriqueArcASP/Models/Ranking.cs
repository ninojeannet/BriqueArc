using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BriqueArcASP.Models
{
    public class Ranking
    {
        public long RankingId { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
