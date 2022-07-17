using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public interface IUserRepository
    {
        Task<bool> Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Delete(string id);
        Task<IEnumerable<UserModel>> GetAll();
        Task<IEnumerable<UserModel>> GetByName(string value); // search
    }
}
