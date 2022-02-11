using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuTOP.WebAPI.Models.ViewModels
{
    public class ReviewViewModel
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public double LikePercentage { get; set; }
    }
}