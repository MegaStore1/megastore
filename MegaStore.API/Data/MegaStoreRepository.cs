using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data
{
    public class MegaStoreRepository : IMegaStoreRepository
    {
        private readonly DataContext context;

        public MegaStoreRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await this.context.Users
            .Include(p => p.plant)
            .Include(p => p.Photos)
            .Include(s => s.state)
            .Include(ur => ur.pages)
            .ThenInclude(urm => urm.module)
            .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = this.context.Users.Include(p => p.Photos).OrderByDescending(u => u.Id).AsQueryable();

            if (!string.IsNullOrEmpty(userParams.email))
                users = users.Where(u => u.email == userParams.email);

            if (!string.IsNullOrEmpty(userParams.orderBy))
            {
                switch (userParams.orderBy)
                {
                    case "username":
                        users = users.OrderBy(u => u.firstName);
                        break;
                    case "":
                        users = users.OrderByDescending(u => u.firstName);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.Id);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.pageNumber, userParams.pageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}