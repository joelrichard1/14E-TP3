using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public class Chauffages : ControlSystem
    { 
        public Chauffages(string status)
        {
            Type = "Chauffages";
            Status = status switch
            {
                "On" or "Off" => status,
                _ => throw new ArgumentException("Status must be 'On' or 'Off'.")
            };
        }

        public override void ControlSystemSerre(int temperature, int humidity, int lux, Tomato tomato, DateTime currentDate, SystemsStatuses statuses)
        {
            bool isDay = currentDate.Hour >= 6 && currentDate.Hour < 18;

            if (isDay)
            {
                Status = (temperature < tomato.DayMinTemperature) ? "On" : "Off";
            }
            else
            {
                Status = (temperature < tomato.NightMinTemperature) ? "On" : "Off";
            }

            statuses.IsHeatingActive = Status == "On";
        }
    }
    
}
