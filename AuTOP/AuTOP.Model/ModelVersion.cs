using AuTOP.Model.Common;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model
{
    public class ModelVersion : DateTimeModel, IModelVersion
    {
        public Guid Id { get; set; }

        public Guid ModelId { get; set; }

        public Guid MotorId { get; set; }

        public Guid BodyShapeId { get; set; }

        public Guid TransmissionId { get; set; }

        public decimal FuelConsumption { get; set; }

        public int Year { get; set; }

        public decimal Acceleration { get; set; }

        public int Doors { get; set; }
        public ModelDomainModel Model { get => model; set => model = value; }
        public Motor Motor { get => motor; set => motor = value; }
        public BodyShape BodyShape { get => bodyShape; set => bodyShape = value; }
        public Transmission Transmission { get => transmission; set => transmission = value; }

        private ModelDomainModel model;
        private Motor motor;
        private BodyShape bodyShape;
        private Transmission transmission;

        public ModelVersion(Guid id, Guid modelId, Guid motorId, Guid bodyShapeId, Guid transmissionId, decimal fuelConsumption, int year, decimal acceleration, int doors,DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            ModelId = modelId;
            MotorId = motorId;
            BodyShapeId = bodyShapeId;
            TransmissionId = transmissionId;
            FuelConsumption = fuelConsumption;
            Year = year;
            Acceleration = acceleration;
            Doors = doors;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;

        }

    }
}
