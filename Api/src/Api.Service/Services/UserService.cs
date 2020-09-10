using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity userEntity)
        {
            return await _repository.InsertAsync(userEntity);
        }

        public async Task<UserEntity> Put(UserEntity userEntity)
        {
            return await _repository.UpdateAsync(userEntity);
        }
    }
}