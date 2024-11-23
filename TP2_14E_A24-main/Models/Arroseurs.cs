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
        public class Arroseurs : ControlSystem
        {
            public Arroseurs(string status)
            {
                Type = "Arroseurs";
                Status = status switch
                {
                    "On" or "Off" => status,
                    _ => throw new ArgumentException("Status must be 'On' or 'Off'.")
                };
            }

            public override void ControlSystemSerre(int temperature, int humidity, int lux, Tomato tomato, DateTime currentDate, SystemsStatuses statuses)
            {
                Status = (humidity < tomato.MinHumidity) ? "On" : "Off";

                statuses.AreSprinklersActive = Status == "On";
            }
        }

    }

}
