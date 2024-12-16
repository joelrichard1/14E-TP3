using Automate.Interfaces;
using Automate.Models;
using Automate.Utils;
using Automate.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace Automate.Views
{
    public partial class EventsFormWindow : Window
    {
        public EventsFormWindow()
        {
            InitializeComponent();
            IMongoDBService mongoService = new MongoDBService("TP3DB");
            DataContext = new EventsFormViewModel(this, mongoService);
        }

        public EventsFormWindow(Tache tache)
        {
            InitializeComponent();
            IMongoDBService mongoService = new MongoDBService("TP3DB");
            DataContext = new EventsFormViewModel(this, mongoService, tache);
        }
    }
}
