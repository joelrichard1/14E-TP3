using Automate.Utils;
using Automate.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Automate.Models
{
    public class DayModel
    {
        public int Day { get; set; }
        public ObservableCollection<Tache> Taches { get; set; } = new ObservableCollection<Tache>();

        public DayModel()
        {
        }

    }
}
