using Contracts.User;

namespace Contracts
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        void Save();
    }
}