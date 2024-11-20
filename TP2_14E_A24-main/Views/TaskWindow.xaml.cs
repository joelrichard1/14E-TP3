using Automate.Models;
using System.Windows;

namespace Automate.Views
{
    public partial class TaskWindow : Window
    {
        public TaskWindow(Tache tache)
        {
            InitializeComponent();
            DataContext = tache;
        }
    }
}
