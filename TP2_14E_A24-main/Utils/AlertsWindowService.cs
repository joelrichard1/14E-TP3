using Automate.Interfaces;
using Automate.Views;
using System.Windows;

namespace Automate.Utils
{
    public class AlertsWindowService : IAlertsWindowService
    {
        public void OpenAlertsWindow()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                AlertsWindow alertsWindow = new();
                alertsWindow.Show();
            });
        }
    }
}
