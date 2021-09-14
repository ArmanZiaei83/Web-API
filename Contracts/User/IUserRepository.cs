using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.User
{
    public interface IUserRepository
    {
        Task<List<Entities.user.User>> GetAll();
        Task Add(Entities.user.User user);

        void DeleteById(int id);
        Task<bool> Exists(int id);
        void Update(Entities.user.User user);
    }
}