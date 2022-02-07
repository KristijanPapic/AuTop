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
        public async Task<List<IUser>> Get()
        {
            return await UserRepository.Get();
        }

        public async Task<List<IUser>> GetById(Guid userId)
        {
            return await UserRepository.GetById(userId);
        }

        public async Task Post(IUser user)
        {
            await UserRepository.Post(user);
        }
    }
}
