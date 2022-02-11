using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class ModelVersionFilter
    {
        private string name = "";
        private Guid modelId = Guid.Empty;
        private Guid motorId = Guid.Empty;
        private Guid transmissionId = Guid.Empty;
        private Guid bodyShapeId = Guid.Empty;

        public Guid ModelId { get => modelId; set => modelId = value; }
        public Guid MotorId { get => motorId; set => motorId = value; }
        public Guid TransmissionId { get => transmissionId; set => transmissionId = value; }
        public Guid BodyShapeId { get => bodyShapeId; set => bodyShapeId = value; }
        public string Name { get => name; set => name = value; }
    }
}
