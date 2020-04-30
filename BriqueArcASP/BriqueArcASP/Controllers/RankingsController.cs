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
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        private readonly BriqueArcContext _context;

        public RankingsController(BriqueArcContext context)
        {
            _context = context;
        }

        [HttpGet("scoreboard")]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetFirsts()
        {
            return await _context.Rankings.OrderByDescending(r => r.Score).ToListAsync();
        }

        [HttpGet("add/{id}/{score}")]
        public async Task<ActionResult<Ranking>> AddRanking(long id, int score)
        {
            Ranking ranking = new Ranking();
            ranking.UserID = id;
            ranking.Score = score;

            return await PostRanking(ranking);
        }

        // GET: api/Rankings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetRankings()
        {
            List<Ranking> rankings = _context.Rankings.ToList();

            return await _context.Rankings.ToListAsync();
        }

        // GET: api/Rankings/5
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

        // PUT: api/Rankings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        // POST: api/Rankings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Ranking>> PostRanking(Ranking ranking)
        {
            _context.Rankings.Add(ranking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRanking", new { id = ranking.RankingId }, ranking);
        }

        // DELETE: api/Rankings/5
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
