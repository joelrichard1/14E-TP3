using System;

namespace Automate.Models
{
    public class Recolte : Tache
    {
        public Recolte(string? description, string? alert, DateTime date)
        {
            Type = "Recolte";
            Description = description;
            Alert = alert;
            Colour = "Yellow";
            Date = date;
        }
    }
}
