using Automate.Models;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Automate.Utils
{
    public static class AdviceUtils
    {
        public const string TurnLightsOn = "Allumer les lumières";
        public const string TurnLightsOff = "Éteindre les lumières";
        public const string TurnHeatingOn = "Allumer le chauffage";
        public const string TurnHeatingOff = "Éteindre le chauffage";
        public const string OpenWindows = "Ouvrir les fenêtres";
        public const string CloseWindows = "Fermer les fenêtres";
        public const string TurnSprinklersOn = "Allumer les arroseurs";
        public const string TurnSprinklersOff = "Éteindre les arroseurs";
        public const string TurnVentilationOn = "Allumer la ventilation";
        public const string TurnVentilationOff = "Éteindre la ventilation";

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
                    advices.Add(TurnHeatingOn);
                }
                if (statuses.AreWindowsActive)
                {
                    advices.Add(CloseWindows);
                }
            }
            else if (currentTemperature > tomato.DayMaxTemperature)
            {
                if (statuses.IsHeatingActive)
                {
                    advices.Add(TurnHeatingOff);
                }
                if (!statuses.AreWindowsActive)
                {
                    advices.Add(OpenWindows);
                }
            }
        }

        public static void EvaluateLuminosityConditions(List<string> advices, TomatoConditions tomato, SystemStatus statuses, int currentLux)
        {

            // Light checks for lights
            if (currentLux < tomato.MinLux && !statuses.AreLightsActive)
            {
                advices.Add(TurnLightsOn);
            }
            else if (currentLux > tomato.MaxLux && statuses.AreLightsActive)
            {
                advices.Add(TurnLightsOff);
            }
        }

        public static void EvaluateHumidityConditions(List<string> advices, TomatoConditions tomato, SystemStatus statuses, int currentHumidity)
        {
            // Humidity checks for sprinklers and ventilation
            if (currentHumidity < tomato.MinHumidity)
            {
                if (!statuses.AreSprinklersActive)
                {
                    advices.Add(TurnSprinklersOn);
                }
                if (statuses.IsVentilationActive)
                {
                    advices.Add(TurnVentilationOff);
                }
            }
            else if (currentHumidity > tomato.MaxHumidity)
            {
                if (statuses.AreSprinklersActive)
                {
                    advices.Add(TurnSprinklersOff);
                }
                if (!statuses.IsVentilationActive)
                {
                    advices.Add(TurnVentilationOn);
                }
            }
        }
    }
}