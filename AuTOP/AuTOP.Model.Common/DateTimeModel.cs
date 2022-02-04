using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model.Common
{
    public abstract class DateTimeModel
    {
       private DateTime dateCreated;
       private DateTime dateUpdated;

        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public DateTime DateUpdated { get => dateUpdated; set => dateUpdated = value; }
    }
}
