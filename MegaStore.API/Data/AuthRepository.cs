using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;

        public AuthRepository(DataContext context)
        {
            this.context = context;

        }

        public async Task<User> Login(string email, string password)
        {
            var user = await this.context.Users.Include(p => p.Photos).Include(o => o.plant).FirstOrDefaultAsync(x => x.Email == email);

            if (null == user) return null;

            if (!Extensions.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Extensions.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await this.context.Users.AnyAsync(x => x.Email == email))
                return true;
            return false;
        }
    }
}