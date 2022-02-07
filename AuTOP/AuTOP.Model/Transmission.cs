using AuTOP.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model
{
    public class Transmission : DateTimeModel, ITransmission
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Gears { get; set; }

    }
}
