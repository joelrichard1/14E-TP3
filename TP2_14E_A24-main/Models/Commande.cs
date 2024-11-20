using System;

namespace Automate.Models
{
    public class Commande : Tache
    {
        public Commande(string? description, string? alert, DateTime date)
        {
            Type = "Commande";
            Description = description;
            Alert = alert;
            Colour = "Purple";
            Date = date;
        }
    }
}
