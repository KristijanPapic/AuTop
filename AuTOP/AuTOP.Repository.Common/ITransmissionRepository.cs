using AuTOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository.Common
{
    public interface ITransmissionRepository
    {
        Task<List<Transmission>> GetAllAsync();

        Task<Transmission> GetByIdAsync(int id);
    }
}
