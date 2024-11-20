using Automate.Models;
using Automate.Utils;
using Automate.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Input;

namespace Automate.ViewModels
{
    public class TasksWindowViewModel
    {
        public ObservableCollection<Tache> Tasks { get; set; }
        public ICommand OpenTaskCommand { get; }
        public ICommand ModifyTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        private readonly MongoDBService _mongoService;
        public Window CurrentWindow { get; set; }

        public TasksWindowViewModel(ObservableCollection<Tache> tasks, Window currentWindow)
        {
            _mongoService = new MongoDBService("AutomateDB");
            Tasks = tasks;

            OpenTaskCommand = new RelayCommand<Tache>(OpenTask!);
            ModifyTaskCommand = new RelayCommand<Tache>(ModifyTask!);
            DeleteTaskCommand = new RelayCommand<Tache>(DeleteTask!);
            CurrentWindow = currentWindow;
        }

        private void OpenTask(Tache task)
        {
            var taskWindow = new TaskWindow(task);
            taskWindow.ShowDialog();
        }

        private void ModifyTask(Tache task)
        {
            EventsFormWindow form = new(task);
            form.ShowDialog();
            CurrentWindow.Close();
        }

        private void DeleteTask(Tache task)
        {
            MessageBoxResult result = MessageBox.Show(
                "Voulez-vous vraiment supprimer cette tâche ?",
                "Confirmation de suppression",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );
            if (result == MessageBoxResult.Yes)
            {
                _mongoService.DeleteTache(task.Id);
                Tasks.Remove(task);
            }
        }
    }
}
