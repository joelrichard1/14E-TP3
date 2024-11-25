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

        public override void ControlSystemSerre(TomatoConditions tomato, GreenhouseCondition condition, SystemStatus status)
        {
            if (IsDay(condition.DateTime))
            {
                Status = (condition.Temperature > tomato.DayMaxTemperature || condition.Humidity > tomato.MaxHumidity) ? "On" : " Off";
            }
            else
            {
                Status = (condition.Temperature > tomato.NightMaxTemperature) ? "On" : "Off";
            }

            status.AreWindowsActive = Status == "On";
        }
    }
}
