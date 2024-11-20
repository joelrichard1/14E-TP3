using Automate.Interfaces;
using Automate.Utils;
using Automate.ViewModels;
using System.Windows;

namespace Automate.Views
{
    public partial class CalendrierWindow : Window
    {
        public CalendrierWindow()
        {
            InitializeComponent();
            IMongoDBService mongoService = new MongoDBService("AutomateDB");
            ICurrentDateProvider currentDateProvider = new CurrentDateProvider();
            DataContext = new CalendarViewModel(this, mongoService, currentDateProvider);
            OpenAlertsWindow();
        }

        private static void OpenAlertsWindow()
        {
            AlertsWindow alertsWindow = new();
            alertsWindow.Show();
        }
    }
}
