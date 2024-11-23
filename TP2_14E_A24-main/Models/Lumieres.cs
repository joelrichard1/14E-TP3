using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public class Lumiere : ControlSystem
    { 
        public Lumiere(string status)
        {
            Type = "lumière";
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
                Status = (lux < tomato.MinLux) ? "On" : "Off";
            }
            else
            {
                Status = "Off"; 
            }
            statuses.AreLightsActive = Status == "On";
        }
    }


}
