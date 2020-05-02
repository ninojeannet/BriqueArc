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
        /// <summary>
        /// Identifiant du score
        /// </summary>
        public long RankingId { get; set; }

        /// <summary>
        /// Le score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// L'identifiant de l'utilisateur ayant fait ce score
        /// </summary>
        public long UserID { get; set; }
    }
}
