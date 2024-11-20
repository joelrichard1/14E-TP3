using System;

namespace Automate.Models
{
    public class Arrosage : Tache
    {
        public Arrosage(string? description, string? alert, DateTime date)
        {
            Type = "Arrosage";
            Description = description;
            Alert = alert;
            Colour = "Blue";
            Date = date;

        }
    }
}
