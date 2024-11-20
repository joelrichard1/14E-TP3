using Automate.Interfaces;
using Automate.ViewModels;
using Automate.Views;
using System.Windows;

namespace Automate.Utils
{
    public class NavigationService
    {
        public static void NavigateTo<T>() where T : Window, new()
        {
            var window = new T();
            window.Show();
        }

        public static void NavigateTo<T>(bool parametre = false) where T : Window, new()
        {
            var window = new T();

            if (window is CalendrierWindow calendrierWindow)
            {
                IMongoDBService mongoService = new MongoDBService("AutomateDB");
                ICurrentDateProvider currentDateProvider = new CurrentDateProvider();

                var viewModel = new CalendarViewModel(calendrierWindow, mongoService, currentDateProvider, isEditMode: parametre);

                calendrierWindow.DataContext = viewModel;
            }
            else if (window is AccueilWindow accueilWindow)
            {
                accueilWindow.DataContext = new AccueilViewModel(isAdmin: parametre);
            }

            window.Show();
        }

        public static void Close(Window window)
        {
            window.Close();
        }
    }
}
