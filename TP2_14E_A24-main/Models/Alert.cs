using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Automate.Models
{
    public class Alert
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Alert")]
        public int AlertData { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        public Alert(string description, TypeAlertInt alert, DateTime date)
        {
            Description = description;
            AlertData = (int)alert;
            Date = date;
        }

        [BsonIgnore]
        public int DaysRemaining => (Date - DateTime.Today).Days;
    }
}
