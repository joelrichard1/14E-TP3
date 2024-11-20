using System;

namespace Automate.Models
{
    public class Evenement : Tache
    {
        public Evenement(string? description, string? alert, DateTime date)
        {
            Type = "Evenement";
            Description = description;
            Alert = alert;
            Colour = "Pink";
            Date = date;
        }
    }
}
