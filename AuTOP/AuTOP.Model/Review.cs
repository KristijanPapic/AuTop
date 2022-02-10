﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;

namespace AuTOP.Model
{
    public class Review : DateTimeModel, IReview
    {
        public Guid ReviewId { get; set; }
        public Guid ModelVersionId { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public int  Rating { get; set; }
        public Task<double> LikePercentage { get; set; }

    }
}
