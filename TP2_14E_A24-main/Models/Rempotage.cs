using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Automate.Models
{
    public class Rempotage : Tache
    {
        public Rempotage(string? description, string? alert, DateTime date)
        {
            Type = "Rempotage";
            Description = description;
            Alert = alert;
            Colour = "Green";
            Date = date;
        }
    }
}
