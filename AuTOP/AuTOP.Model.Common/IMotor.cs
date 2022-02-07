using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model.Common
{
    public interface IMotor
    {
        Guid Id { get; set;}
        
        int Year { get; set; }

        string Type { get; set; }

        int MaxHP { get; set; }

        int EngineSize { get; set; }

        string Name { get; set; }


    }
}
