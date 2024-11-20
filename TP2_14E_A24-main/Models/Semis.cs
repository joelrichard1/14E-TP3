using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Automate.Models
{
    public class Semis : Tache
    {
        public Semis(string? description, string? alert, DateTime? date)
        {
            Type = "Semis";
            Description = description;
            Alert = alert;
            Colour = "Red";
            Date = date;

        }
    }
}
