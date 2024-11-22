using Automate.Models;
using Automate.Utils;
using Automate.Views;
using System.Windows;
using System.Windows.Input;

namespace Automate.ViewModels
{
    public class AccueilViewModel
    {
        public ICommand ViewCalendrierCommand { get; }
        public ICommand ViewGreenHouseCommand { get; }
        public ICommand EditCalendrierCommand { get; }
        public static User? User => ((App)Application.Current).CurrentUser;
        private bool _isAdmin;
        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                }
            }
        }

        public AccueilViewModel(bool isAdmin)
        {
            IsAdmin = isAdmin;
            ViewCalendrierCommand = new RelayCommand(OpenCalendrier);
            ViewGreenHouseCommand = new RelayCommand(OpenGreenHouse);
            EditCalendrierCommand = new RelayCommand(EditCalendrier);
        }

        public static void OpenCalendrier()
        {
            NavigationService.NavigateTo<CalendrierWindow>(false);
        }

        public static void OpenGreenHouse()
        {
            NavigationService.NavigateTo<GreenHouseWindow>(false);
        }

        public static void EditCalendrier()
        {
            NavigationService.NavigateTo<CalendrierWindow>(true);
        }
    }
}
