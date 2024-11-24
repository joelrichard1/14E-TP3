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

        public override void ControlSystemSerre(TomatoConditions tomato, DateTime currentDate, SystemStatus status)
        {
            if (IsDay(currentDate))
            {
                Status = (status.temperature < tomato.DayMinTemperature) ? "On" : "Off";
            }
            else
            {
                Status = (status.temperature < tomato.NightMinTemperature) ? "On" : "Off";
            }

            status.IsHeatingActive = Status == "On";
        }
    }
}
