using Automate.Models;
using Automate.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System;

namespace Automate.Views
{
    public partial class TasksWindow : Window
    {
        public User CurrentUser => (Application.Current as App)?.CurrentUser;

        public TasksWindow(ObservableCollection<Tache> tasks)
        {
            InitializeComponent();
            DataContext = new TasksWindowViewModel(tasks, this);
            Dispatcher.BeginInvoke(new Action(ConfigureButtonVisibility), System.Windows.Threading.DispatcherPriority.Loaded);
        }

        private void ConfigureButtonVisibility()
        {
            var itemsControl = TasksItemsControl;

            if (itemsControl != null)
            {
                var buttons = FindVisualChildren<Button>(itemsControl).ToList();
                bool isAdmin = CurrentUser?.Role.Equals("admin", StringComparison.OrdinalIgnoreCase) ?? false;

                foreach (var button in buttons)
                {
                    if (button.Name == "btn_delete" || button.Name == "btn_update")
                    {
                        button.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T)
                        yield return (T)child;

                    foreach (var childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
