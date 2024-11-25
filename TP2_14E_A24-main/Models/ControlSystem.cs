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
        public string Type { get; set; }
        public string Status { get; set; } = "Off";
        protected bool IsDay(DateTime currentDate) => currentDate.Hour >= 6 && currentDate.Hour < 18;

        public abstract void ControlSystemSerre(TomatoConditions tomato, GreenhouseCondition condition, SystemStatus status);
    }
}

