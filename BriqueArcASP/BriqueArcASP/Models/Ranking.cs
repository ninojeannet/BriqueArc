using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public long UserID { get; set; }
    }
}
