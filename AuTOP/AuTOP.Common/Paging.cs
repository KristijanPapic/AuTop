﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class Paging
    {
        private int rpp = 10;
        private int page;

        public Paging(int rpp, int page)
        {
            Rpp = rpp;
            Page = page;
        }

        public int Rpp { get => rpp; set => rpp = value; }
        public int Page { get => page; set => page = value; }

        public int GetStartElement()
        {
            return rpp * (page - 1);
        }
    }
}
