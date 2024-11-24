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
        public override void ControlSystemSerre(TomatoConditions tomato, DateTime currentDate, SystemStatus status)
        {
            if (IsDay(currentDate))
            {
                Status = (status.lux < tomato.MinLux) ? "On" : "Off";
            }
            else
            {
                Status = "Off"; 
            }
            status.AreLightsActive = Status == "On";
        }
    }
}
