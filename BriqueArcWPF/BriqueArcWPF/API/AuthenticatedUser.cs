using BriqueArcWPF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.API
{
    class AuthenticatedUser
    {
        private static AuthenticatedUser instance;
        private User user;

        public static  AuthenticatedUser GetInstance()
        {
            if (instance == null)
                instance = new AuthenticatedUser();

            return instance;
        }

        public bool Authenticated()
        {
            return (user != null);
        }

        public void Disconnect()
        {
            user = null;
        }

        public void SetUser(User user)
        {
            this.user = user;
        }

        public int Id
        {
            get { return user.getId(); }
        }

        public String Username
        {
            get { return user.getUsername(); }
        }
    }
}
