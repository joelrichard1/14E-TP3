using Automate.Models;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Automate.Utils
{
    public static class AdviceUtils
    {
        public static List<string> EvaluateConditions(TomatoConditions tomato, SystemStatus statuses, int currentTemperature, int currentLux, int currentHumidity)
        {
            // Clear previous advices
            List<string> advices = new List<string>();

            EvaluateTemperatureConditions(advices, tomato, statuses, currentTemperature);
            EvaluateHumidityConditions(advices, tomato, statuses, currentHumidity);
            EvaluateLuminosityConditions(advices, tomato, statuses, currentLux);

            return advices;
        }

        public static void EvaluateTemperatureConditions(List<string> advices, TomatoConditions tomato, SystemStatus statuses, int currentTemperature)
        {
            // Temperature checks for heating and windows
            if (currentTemperature < tomato.DayMinTemperature)
            {
                if (!statuses.IsHeatingActive)
                {
                    advices.Add("Allumer le chauffage");
                }
                if (statuses.AreWindowsActive)
                {
                    advices.Add("Fermer les fenêtres");
                }
            }
            else if (currentTemperature > tomato.DayMaxTemperature)
            {
                if (statuses.IsHeatingActive)
                {
                    advices.Add("Éteindre le chauffage");
                }
                if (!statuses.AreWindowsActive)
                {
                    advices.Add("Ouvrir les fenêtres");
                }
            }
        }

        public static void EvaluateLuminosityConditions(List<string> advices, TomatoConditions tomato, SystemStatus statuses, int currentLux)
        {

            // Light checks for lights
            if (currentLux < tomato.MinLux && !statuses.AreLightsActive)
            {
                advices.Add("Allumer les lumières");
            }
            else if (currentLux > tomato.MaxLux && statuses.AreLightsActive)
            {
                advices.Add("Éteindre les lumières");
            }
        }

        public static void EvaluateHumidityConditions(List<string> advices, TomatoConditions tomato, SystemStatus statuses, int currentHumidity)
        {
            // Humidity checks for sprinklers and ventilation
            if (currentHumidity < tomato.MinHumidity)
            {
                if (!statuses.AreSprinklersActive)
                {
                    advices.Add("Allumer les arroseurs");
                }
                if (statuses.IsVentilationActive)
                {
                    advices.Add("Éteindre la ventilation");
                }
            }
            else if (currentHumidity > tomato.MaxHumidity)
            {
                if (statuses.AreSprinklersActive)
                {
                    advices.Add("Éteindre les arroseurs");
                }
                if (!statuses.IsVentilationActive)
                {
                    advices.Add("Allumer la ventilation");
                }
            }
        }
    }
}