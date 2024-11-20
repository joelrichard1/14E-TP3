using Automate.Models;
using System.Collections.Generic;

namespace Automate.Interfaces
{
    public interface IMongoDBService
    {
        User? Authenticate(string Username, string Password);
        List<Tache> GetTachesForMonth(int year, int month);
        List<Alert> GetAllAlerts();
        void AjouterTache(Tache tache);
        void UpdateTask(Tache tache);
    }
}
