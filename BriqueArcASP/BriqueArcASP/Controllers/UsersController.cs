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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BriqueArcContext _context;

        public UsersController(BriqueArcContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("exists/{username}")]
        public async Task<ActionResult<bool>> UsernameAlreadyExist(String username)
        {
            return await _context.Users.Where(s => s.Username == username).CountAsync() > 0;
        }

        [HttpGet("connect/{username}/{password}")]
        public async Task<ActionResult<bool>> ConnectUser(String username, String password)
        {
            return await _context.Users.Where(s => s.Username == username && s.Password == password).CountAsync() > 0;
        }

        [HttpGet("register/{username}/{password}")]
        public async void RegisterUser(String username, String password)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // GET: api/Users/5
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

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var md5 = new MD5CryptoServiceProvider();

            //return as base64 string
            user.Password =  Convert.ToBase64String(md5.ComputeHash(Encoding.Unicode.GetBytes(user.Password)));

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
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
