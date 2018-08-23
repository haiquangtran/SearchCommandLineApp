using SearchCommandLineApp.Models;
using SearchCommandLineApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IEnumerable<User> _users;

        public UserRepository(IEnumerable<User> users)
        {
            _users = users;
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }
    }
}
