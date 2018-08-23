using SearchCommandLineApp.Models;
using System.Collections.Generic;

namespace SearchCommandLineApp.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}