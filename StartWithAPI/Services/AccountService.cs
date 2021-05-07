using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public class AccountService : IAccountService
    {
        private AppContext _context;

        public AccountService(AppContext context)
        {
            _context = context;
        }


        public async Task<AppUser> RegisterAsync(string userName, string password)
        {
            // gebruik maken van ingebouwde library van cryptografie
            using var hmac = new HMACSHA512();
            //using om gegevens manueel te disposen. Daar waar anders de garbagecollector gegevens gaat disposen van zodra ze uit de scope vallen.
            // of " using(var hmac = new HMACSHA512()) " (oude manier van schrijven)

            //Hash user password
            var user = new AppUser
            {
                Name = userName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // normaagezien geen goed idee om in deze methode iets te returnen
            return user;
        }
    }
}
