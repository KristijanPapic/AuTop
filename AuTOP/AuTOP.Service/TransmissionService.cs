﻿using AuTOP.Common;
using AuTOP.Model;
using AuTOP.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    public class TransmissionService : ITransmissionService
    {
        protected ITransmissionService BodyShapeRepository { get; set; }
        public TransmissionService(ITransmissionService bodyShape)
        {
            this.BodyShapeRepository = bodyShape;
        }
        public TransmissionService()
        {
           
        }


        public async Task<List<Transmission>> GetAllAsync(TransmissionFilter filter, Sorting sort, Paging paging)
        {
            return await BodyShapeRepository.GetAllAsync(filter, sort, paging);
        }


        public async Task<Transmission> GetByIdAsync(Guid id)
        {
            return await BodyShapeRepository.GetByIdAsync(id);
        }


    }

}
