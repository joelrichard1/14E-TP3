using System;

namespace Automate.Models
{
    public class Entretien : Tache
    {
        public Entretien(string? description, string? alert, DateTime date)
        {
            Type = "Entretien";
            Description = description;
            Alert = alert;
            Colour = "Orange";
            Date = date;

        }
    }
}
