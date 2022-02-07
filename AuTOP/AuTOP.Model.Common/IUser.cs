using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model.Common
{
    public interface IUser
    {
        Guid UserId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }

    }
}
