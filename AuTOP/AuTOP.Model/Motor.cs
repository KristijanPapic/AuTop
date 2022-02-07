using AuTOP.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model
{
    public class Motor : DateTimeModel, IMotor
    {
        public Guid Id { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public int MaxHP { get; set; }

        public int EngineSize { get; set; }

        public string Name { get; set; }
    }
}
