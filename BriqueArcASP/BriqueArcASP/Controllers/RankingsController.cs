using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BriqueArcASP.Models;

namespace BriqueArcASP.Controllers
{
    /// <summary>
    /// Controleur de tout ce qui concerne les résultats
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        private readonly BriqueArcContext _context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context">Contexte de l'API</param>
        public RankingsController(BriqueArcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande la liste de tous les scores trié du plus grand au plus petit
        /// </summary>
        /// <returns>La liste des scores triée</returns>
        [HttpGet("scoreboard")]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetFirsts()
        {
            return await _context.Rankings.OrderByDescending(r => r.Score).ToListAsync();
        }


        /// <summary>
        /// Demande la liste non-trié des scores
        /// </summary>
        /// <returns>La liste des scores</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetRankings()
        {
            List<Ranking> rankings = _context.Rankings.ToList();

            return await _context.Rankings.ToListAsync();
        }

        /// <summary>
        /// Demande un score ayant l'identifiant passé en paramêtre
        /// </summary>
        /// <param name="id">L'identifiant</param>
        /// <returns>Le score</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Ranking>> GetRanking(long id)
        {
            var ranking = await _context.Rankings.FindAsync(id);
            
            if (ranking == null)
            {
                return NotFound();
            }

            return ranking;
        }

        /// <summary>
        /// Ajoute un score à l'aide de la méthode PUT
        /// </summary>
        /// <param name="id">L'identifiant</param>
        /// <param name="ranking">Le score</param>
        /// <returns>Rien</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRanking(long id, Ranking ranking)
        {
            if (id != ranking.RankingId)
            {
                return BadRequest();
            }

            _context.Entry(ranking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Ajoute un score à l'aide de la méthode POST
        /// </summary>
        /// <param name="ranking">Le score à ajouter</param>
        /// <returns>Le score ajouté</returns>
        [HttpPost]
        public async Task<ActionResult<Ranking>> PostRanking(Ranking ranking)
        {
            _context.Rankings.Add(ranking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRanking", new { id = ranking.RankingId }, ranking);
        }

        /// <summary>
        /// Supprime un score ayant l'identifiant passé en paramêtre
        /// </summary>
        /// <param name="id">L'identifiant du score à supprimer</param>
        /// <returns>Le score supprimé</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ranking>> DeleteRanking(long id)
        {
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }

            _context.Rankings.Remove(ranking);
            await _context.SaveChangesAsync();

            return ranking;
        }

        private bool RankingExists(long id)
        {
            return _context.Rankings.Any(e => e.RankingId == id);
        }
    }
}
