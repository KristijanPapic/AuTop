using AuTOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Service.Common
{
    public interface IMotorService
    {
        Task<List<Motor>> GetAllAsync();

        Task<Motor> GetByIdAsync(Guid id);

        Task<bool> PostAsync(Motor motor);


        Task<bool> PutAsync(Motor motor);


        Task<bool> DeleteAsync(Guid Id);
        

    }
}
