using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public class Fenetres : ControlSystem
    {
        public Fenetres( string status)
        {
            Type = "Fenêtres";
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
                Status = (status.temperature > tomato.DayMaxTemperature || status.humidity > tomato.MaxHumidity) ? "On" : " Off";
            }
            else
            {
                Status = (status.temperature > tomato.NightMaxTemperature) ? "On" : "Off";
            }

            status.AreWindowsActive = Status == "On";
        }
    }
}
