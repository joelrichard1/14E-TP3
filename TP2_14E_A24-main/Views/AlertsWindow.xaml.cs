using Automate.Interfaces;
using Automate.Utils;
using Automate.ViewModels;
using System.Windows;

namespace Automate.Views
{
    public partial class AlertsWindow : Window
    {
        public AlertsWindow()
        {
            InitializeComponent();
            IMongoDBService mongoService = new MongoDBService("TP3DB");
            DataContext = new AlertsViewModel(mongoService);
        }
    }
}
