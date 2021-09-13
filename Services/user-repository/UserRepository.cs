using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Contracts.User;
using EFCore;
using Entities.user;
using Microsoft.EntityFrameworkCore;

namespace Services.user_repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext Context = UserDbContext.GetContext();

        public void Add(User user)
        {
            Context.Add(user);
        }

        public void PutUpdate(int id, string name, string email, string password)
        {
            var result = Context.Users.SingleOrDefault(b => b.UserId == id);
            if (result == null) return;
            result.UserName = name;
            result.UserEmail = email;
            result.UserPassword = password;
        }

        public void PatchUpdate(int id, string name, string password, string email)
        {
            var user = Context.Users.Find(id);
            Context.Users.Attach(user);
            name = user.UserName;
            email = user.UserEmail;
            password = user.UserPassword;

            var newUser = new User()
            {
                UserName = name,
                UserEmail = email,
                UserPassword = password,
                UserId = id
            };

            Context.Users.Update(newUser);
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public void DeleteById(int userId)
        {
            Context.Users.Remove(new User()
            {
                UserId = userId
            });
        }

        public bool Exists(int id)
        {
            return Context.Users.Contains(new User()
            {
                UserId = id
            });
        }
    }
}