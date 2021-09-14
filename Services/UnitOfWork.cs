using System.Threading.Tasks;
using Contracts;
using Contracts.User;
using EFCore;
using Services.user_repository;

namespace Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext Context = UserDbContext.GetContext();

        public IUserRepository UserRepository
        {
            get => new UserRepository();
            set { }
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}