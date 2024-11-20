using Automate.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Automate.ViewModels
{
    public class TasksViewModel
    {
        public ObservableCollection<Tache> Tasks { get; }
        public ICommand OpenTaskCommand { get; }

        public bool IsAdmin { get; }

        public TasksViewModel(ObservableCollection<Tache> tasks, ICommand iOpenTaskCommand, object window)
        {
            Tasks = tasks;
            OpenTaskCommand = iOpenTaskCommand;

        }
    }
}
