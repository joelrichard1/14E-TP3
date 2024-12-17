using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using Automate.Interfaces;

namespace Automate.Models
{
    public class Tache : ITache
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Colour")]
        public string? Colour { get; set; }

        [BsonElement("Type")]
        public string? Type { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("Alert")]
        public virtual string? Alert { get; set; }

        [BsonElement("Date")]
        public DateTime? Date { get; set; }

        internal static Tache CreateInstance(string type, string description, string alert, DateTime dateTime)
        {
            return type switch
            {
                "Arrosage" => new Arrosage(description, alert, dateTime),
                "Commande" => new Commande(description, alert, dateTime),
                "Entretien" => new Entretien(description, alert, dateTime),
                "Evenement" => new Evenement(description, alert, dateTime),
                "Recolte" => new Recolte(description, alert, dateTime),
                "Rempotage" => new Rempotage(description, alert, dateTime),
                "Semis" => new Semis(description, alert, dateTime),
                _ => throw new ArgumentException("Type de tâche inconnu", nameof(type)),
            };
        }
    }
}
