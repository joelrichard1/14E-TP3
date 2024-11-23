using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public abstract class ControlSystem
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Type")]
        public string Type { get; set; }
        [BsonElement("Status")]
        public string Status { get; set; } = "Off";

        public abstract void ControlSystemSerre(int temperature, int humidity, int lux, Tomato tomato, DateTime currentDate, SystemsStatuses statuses);    
    }
}

