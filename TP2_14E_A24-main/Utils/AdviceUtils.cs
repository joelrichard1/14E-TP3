using Automate.Models;

namespace Automate.Utils
{
    public static class AdviceUtils
    {
        public static void EvaluateConditions(Advice advice, Tomato tomato, SystemsStatuses statuses, double currentTemperature, int currentLux, double currentHumidity)
        {
            // Clear previous advices
            advice.Advices.Clear();

            // Temperature checks for heating and windows
            if (currentTemperature < tomato.MinTemperature)
            {
                if (!statuses.IsHeatingActive)
                {
                    advice.Advices.Add("Allumer le chauffage");
                }
                if (statuses.AreWindowsActive)
                {
                    advice.Advices.Add("Fermer les fenêtres");
                }
            }
            else if (currentTemperature > tomato.MaxTemperature)
            {
                if (statuses.IsHeatingActive)
                {
                    advice.Advices.Add("Éteindre le chauffage");
                }
                if (!statuses.AreWindowsActive)
                {
                    advice.Advices.Add("Ouvrir les fenêtres");
                }
            }

            // Light checks for lights
            if (currentLux < tomato.MinLux && !statuses.AreLightsActive)
            {
                advice.Advices.Add("Allumer les lumières");
            }
            else if (currentLux > tomato.MaxLux && statuses.AreLightsActive)
            {
                advice.Advices.Add("Éteindre les lumières");
            }

            // Humidity checks for sprinklers and ventilation
            if (currentHumidity < tomato.MinHumidity)
            {
                if (!statuses.AreSprinklersActive)
                {
                    advice.Advices.Add("Allumer les arroseurs");
                }
                if (statuses.IsVentilationActive)
                {
                    advice.Advices.Add("Éteindre la ventilation");
                }
            }
            else if (currentHumidity > tomato.MaxHumidity)
            {
                if (statuses.AreSprinklersActive)
                {
                    advice.Advices.Add("Éteindre les arroseurs");
                }
                if (!statuses.IsVentilationActive)
                {
                    advice.Advices.Add("Allumer la ventilation");
                }
            }
        }
    }
}