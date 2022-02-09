﻿using AuTOP.Model;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuTOP.WebAPI.Models.ViewModels
{
    public class ModelVersionViewModel
    {
        private Guid id;
        private ModelViewModel model;
        private MotorViewModel motor;

        public Guid Id { get => id; set => id = value; }
        public ModelViewModel Model { get => model; set => model = value; }
        public MotorViewModel Motor { get => motor; set => motor = value; }
    }
}