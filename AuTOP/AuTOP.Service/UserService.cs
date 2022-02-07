using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;
using AuTOP.Repository;
using AuTOP.Repository.Common;
using AuTOP.Service.Common;

namespace AuTOP.Service
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }
        protected IUserRepository UserRepository { get; set; }
        public async Task<List<IUser>> GetAsync()
        {
            return await UserRepository.GetAsync();
        }

        public async Task<IUser> GetByIdAsync(Guid userId)
        {
            return await UserRepository.GetByIdAsync(userId);
        }

        public async Task PostAsync(IUser user)
        {
            await UserRepository.PostAsync(user);
        }
        public async Task PutAsync(Guid userId, IUser user)
        {
            await UserRepository.PutAsync(userId, user);
        }
        public async Task DeleteAsync(Guid userId)
        {
            await UserRepository.DeleteAsync(userId);
        }
    }
}
