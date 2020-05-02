using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BriqueArcASP.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BriqueArcASP.Controllers
{
    /// <summary>
    /// Controleur pour tout ce qui concerne les utilisateurs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BriqueArcContext _context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context">Contexte de l'API</param>
        public UsersController(BriqueArcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Demande la liste de tous les utilisateurs
        /// </summary>
        /// <returns>La liste de tout les utilisateur</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Demande si un utilisateur utilise déjà un nom d'utilisateur
        /// </summary>
        /// <param name="username">Le nom d'utilisateurà vérifier</param>
        /// <returns>Le nom de compte existe ?</returns>
        [HttpGet("exists/{username}")]
        public async Task<ActionResult<bool>> UsernameAlreadyExist(String username)
        {
            return await _context.Users.Where(s => s.Username == username).CountAsync() > 0;
        }

        /// <summary>
        /// Essaye de connecter un utilisateur avec un couple nom de compte et mot de passe
        /// </summary>
        /// <param name="username">Le nom de compte</param>
        /// <param name="password">Le mot de passe</param>
        /// <returns>L'utilisateur correspondant au nom de compte et au mot de passe</returns>
        [HttpGet("connect/{username}/{password}")]
        public async Task<ActionResult<User>> ConnectUser(String username, String password)
        {
            return await _context.Users.Where(s => s.Username == username && s.Password == password).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Recherche un utilisateur en fonction de son identifiant
        /// </summary>
        /// <param name="id">L'identifiant</param>
        /// <returns>L'utilisateur ayant l'identifiant</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /// <summary>
        /// Enregistre un utilisateur à l'aide de la méhode PUT
        /// </summary>
        /// <param name="id">L'identifiant</param>
        /// <param name="user">L'utilisateur</param>
        /// <returns>Rien</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        /// Enregistre un utilisateur en passant par la méthode POST
        /// </summary>
        /// <param name="user">L'utilisateur à enregistrer</param>
        /// <returns>L'utilisateur enregistré</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        /// <summary>
        /// Supprime un utilisateur ayant l'identifiant passé en paramètre
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à supprimer</param>
        /// <returns>L'utilisateur supprimé</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
