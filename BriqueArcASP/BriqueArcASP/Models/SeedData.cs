using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriqueArcASP.Models
{
    public class SeedData
    {
        private static HashSet<User> setUsers;
        private static HashSet<Ranking> setRankings;


        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BriqueArcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BriqueArcContext>>()))
            {
                // Look for any events.
                if (context.Users.Any())
                {
                    setUsers = context.Users.ToHashSet<User>();
                    context.Users.RemoveRange(setUsers);
                    //Modifier ici
                }
                if (context.Rankings.Any())
                {
                    setRankings= context.Rankings.ToHashSet<Ranking>();
                    context.Rankings.RemoveRange(setRankings);
                    //Modifier ici
                }

                User u1 = new User
                {
                    Username = "nino",
                    Password = "admin",
                };

                User u2 = new User
                {
                    Username = "yohann",
                    Password = "admin",
                };
                User u3 = new User
                {
                    Username = "kevin",
                    Password = "admin",
                };

                context.Users.AddRange(u1, u2, u3);

                context.SaveChanges();

                Ranking r1 = new Ranking
                {
                    //Date = DateTime.Today,
                    Score = 100,
                    UserId = context.Users.Single(s => s.Username == "nino").UserId
                };

                Ranking r2 = new Ranking
                {
                    //Date = DateTime.Today,
                    Score = 10,
                    UserId = context.Users.Single(s => s.Username == "yohann").UserId
                };
                Ranking r3 = new Ranking
                {
                    //Date = DateTime.Today,
                    Score = 50,
                    UserId = context.Users.Single(s => s.Username == "kevin").UserId
                };




                context.Rankings.AddRange(r1, r2, r3);
                context.SaveChanges();
            }
        }
    }
}
