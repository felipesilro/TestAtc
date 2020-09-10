using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Mvc.Models;

namespace Api.Mvc.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAll(string term);
        Task<UserModel> Get(int id);
        Task<bool> Put(UserModel user);
        Task<bool> Post(UserModel user);
        Task<bool> Delete(int id);
    }
}