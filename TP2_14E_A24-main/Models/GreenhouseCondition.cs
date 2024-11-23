using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public class GreenhouseCondition
    {
        [Name("DateTime")]
        public DateTime DateTime { get; set; }

        [Name("Température (°C)")]
        public int Température { get; set; }

        [Name("Humidité (%)")]
        public int Humidité { get; set; }

        [Name("Luminosité (lux)")]
        public int Luminosité { get; set; }
    }


}
