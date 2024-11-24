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

            public override void ControlSystemSerre(TomatoConditions tomato, DateTime currentDate, SystemStatus status)
            {
                if (IsDay(currentDate))
                {
                    Status = (status.temperature < tomato.DayMinTemperature || status.humidity > tomato.MaxHumidity) ? "On" : "Off";
                }
                else
                {
                    Status = (status.temperature < tomato.NightMinTemperature) ? "On" : "Off";
                }

                status.IsVentilationActive = Status == "On";
            }
        }
    }
}
