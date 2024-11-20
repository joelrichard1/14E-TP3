using MongoDB.Bson;
using System;

namespace Automate.Interfaces
{
    public interface ITache
    {
        ObjectId Id { get; set; }
        string? Colour { get; set; }
        string? Alert { get; set; }
        string? Type { get; set; }
        string? Description { get; set; }
        DateTime? Date { get; set; }
    }

}
