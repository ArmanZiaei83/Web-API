using System.Collections.Generic;

namespace Contracts.User
{
    public interface IUserRepository
    {
        void Add(Entities.user.User user);
        void PutUpdate(int id, string name, string email, string password);
        void PatchUpdate(int id, string name, string password, string email);
        List<Entities.user.User> GetAll();
        void DeleteById(int userId);
        bool Exists(int id);
    }
}