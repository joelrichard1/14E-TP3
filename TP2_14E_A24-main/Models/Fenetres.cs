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

        public override void ControlSystemSerre(int temperature, int humidity, int lux, Tomato tomato, DateTime currentDate, SystemsStatuses statuses)
        {
            bool isDay = currentDate.Hour >= 6 && currentDate.Hour < 18;

            if (isDay)
            {
                Status = (temperature > tomato.DayMaxTemperature || humidity > tomato.MaxHumidity) ? "On" : " Off";
            }
            else
            {
                Status = (temperature > tomato.NightMaxTemperature) ? "On" : "Off";
            }

            statuses.AreWindowsActive = Status == "On";
        }
    }
}
