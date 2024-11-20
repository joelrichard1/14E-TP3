using Automate.Interfaces;
using Automate.Utils;
using Automate.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Automate
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            IMongoDBService mongoService = new MongoDBService("AutomateDB");
            DataContext = new LoginViewModel(this, mongoService);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel && sender is PasswordBox passwordBox)
            {
                viewModel.Password = passwordBox.Password;
            }
        }
    }
}
