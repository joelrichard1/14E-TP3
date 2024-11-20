using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Interfaces
{
    public interface IUser
    {
        ObjectId Id { get; set; }
        string? Username { get; set; }
        string? Password { get; set; }
        string? Role { get; set; }
    }
}
