using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;

namespace AuTOP.Service.Common
{

    public interface IBodyShape
    {
        Guid Id { get; set; }

        string Name { get; set; }


    }
}
