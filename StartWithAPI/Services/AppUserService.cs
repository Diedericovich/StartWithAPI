using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public class AppUserService
    {
        private List<AppUser> _users = new List<AppUser>
        {
            new AppUser {Id = 1, Name = "Mark"},
            new AppUser {Id = 2, Name = "Ludwig"},
            new AppUser {Id = 3, Name = "Tony"},
            new AppUser {Id = 4, Name = "Hedwig"},
            new AppUser {Id = 5, Name = "Patrick"},
        };

        public List<AppUser> GetUsers()
        {
            return _users;

        }

        public void AddUser(AppUser user)
        {
            _users.Add(user);
        }

        public AppUser GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
