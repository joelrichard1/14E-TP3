using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Automate.Models
    {
        public class Ventilateurs : ControlSystem
        {
            public Ventilateurs(string status)
            {
                Type = "Ventilateurs";
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
                    Status = (temperature < tomato.DayMinTemperature || humidity > tomato.MaxHumidity) ? "On" : "Off";
                }
                else
                {
                    Status = (temperature < tomato.NightMinTemperature) ? "On" : "Off";
                }

                statuses.IsVentilationActive = Status == "On";
            }
        }

    }

}
