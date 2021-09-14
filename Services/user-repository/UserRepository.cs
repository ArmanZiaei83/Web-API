using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.User;
using EFCore;
using Entities.user;
using Microsoft.EntityFrameworkCore;

namespace Services.user_repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext Context = UserDbContext.GetContext();

        public async Task<List<User>> GetAll()
        {
            return await Context.Users.ToListAsync();
        }

        public async Task Add(User user)
        {
            await Context.Users.AddAsync(user);
        }

        public void DeleteById(int id)
        {
            Context.Users.Remove(Context.Users.Find(id));
        }

        public async Task<bool> Exists(int id)
        {
            return await Context.Users.ContainsAsync(new User
            {
                UserId = id
            });
        }

        public void Update(User user)
        {
            try
            {
                var DataList = GetAll().Result.Where(x => x.UserId == user.UserId).ToList();
                foreach (var item in DataList) Context.Users.Update(item);
            }
            catch (Exception)
            {
            }
        }
    }
}