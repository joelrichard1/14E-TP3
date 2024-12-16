using Automate.Models;
using System;
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

        public static List<string> EvaluateConditions(ICropConditions tomato, SystemStatus statuses, GreenhouseCondition condition)
        {
            List<string> advices = new List<string>();

            EvaluateTemperatureConditions(advices, tomato, statuses, condition.Temperature, condition.DateTime);
            EvaluateHumidityConditions(advices, tomato, statuses, condition.Humidity);
            EvaluateLuminosityConditions(advices, tomato, statuses, condition.Luminosity, condition.DateTime);

            return advices;
        }

        public static void EvaluateTemperatureConditions(List<string> advices, ICropConditions tomato, SystemStatus statuses, int currentTemperature, DateTime currentDatetime)
        {
            bool isDay = IsDay(currentDatetime);
            int minTemperature = isDay ? tomato.DayMinTemperature : tomato.NightMinTemperature;
            int maxTemperature = isDay ? tomato.DayMaxTemperature : tomato.NightMaxTemperature;

            if (currentTemperature < minTemperature)
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
            else if (currentTemperature > maxTemperature)
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

        public static void EvaluateLuminosityConditions(List<string> advices, ICropConditions tomato, SystemStatus statuses, int currentLux, DateTime currentDatetime)
        {
             bool isDay = IsDay(currentDatetime);
            if (isDay)
            {
                if (statuses.AreLightsActive)
                {
                    advices.Add(TurnLightsOff);
                }
                return;
            }

            if (currentLux < tomato.MinLux && !statuses.AreLightsActive)
            {
                advices.Add(TurnLightsOn);
            }
            else if (currentLux > tomato.MaxLux && statuses.AreLightsActive)
            {
                advices.Add(TurnLightsOff);
            }
        }

        public static void EvaluateHumidityConditions(List<string> advices, ICropConditions tomato, SystemStatus statuses, int currentHumidity)
        {
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

        private static bool IsDay(DateTime currentDate) => currentDate.Hour >= 6 && currentDate.Hour < 18;
    }
}