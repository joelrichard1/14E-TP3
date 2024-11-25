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

            public override void ControlSystemSerre(TomatoConditions tomato, GreenhouseCondition condition, SystemStatus status)
            {
                if (IsDay(condition.DateTime))
                {
                    Status = (condition.Temperature < tomato.DayMinTemperature || condition.Humidity > tomato.MaxHumidity) ? "On" : "Off";
                }
                else
                {
                    Status = (condition.Temperature < tomato.NightMinTemperature) ? "On" : "Off";
                }

                status.IsVentilationActive = Status == "On";
            }
        }
    }
}
