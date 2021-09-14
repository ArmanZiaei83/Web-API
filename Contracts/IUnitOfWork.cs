using System.Threading.Tasks;
using Contracts.User;

namespace Contracts
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        Task Save();
    }
}