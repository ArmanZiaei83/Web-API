using Contracts;
using Contracts.User;
using EFCore;
using Services.user_repository;

namespace Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserDbContext Context = UserDbContext.GetContext();

        public IUserRepository UserRepository
        {
            get => new UserRepository();
            set { }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}