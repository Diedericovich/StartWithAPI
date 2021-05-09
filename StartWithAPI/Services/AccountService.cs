using Microsoft.EntityFrameworkCore;
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
                Name = userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // normaal gezien geen goed idee om in deze methode iets te returnen
            return user;
        }

        // checken of een gebruiker al bestaat om zo ja, een foutboodschap terug te geven
        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }



        public async Task<AppUser> LoginAsync(string name, string password)
        {
            AppUser user = await _context.Users
                        .SingleOrDefaultAsync(x => x.Name == name);
            // extra check bij het zoeken van een user en als er meer dan 1 user terug wordt gevonden, geeft die een fout terug
            // extra beveiliging!
           
            //Bad Practice: Flat out tells a hacker that this name does / does not exist
            if (user == null)
            {
                //Throw error if no user is found
                throw new UnauthorizedAccessException("Invalid username");
            }

            // if user was found, compare password hashes to verify correct password
            // Hash password again with users personal salt to get same hash result.
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hash.Length; i++)
            {
                // Collections cannot be compared directly. We need to check their values.
                if (hash[i] != user.PasswordHash[i])
                {
                    throw new UnauthorizedAccessException("Invalid password");
                }
            }
            return user;
        }

    }
}
