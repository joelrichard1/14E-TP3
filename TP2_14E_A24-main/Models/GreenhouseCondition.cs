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
        public int Temperature { get; set; }

        [Name("Humidité (%)")]
        public int Humidity { get; set; }

        [Name("Luminosité (lux)")]
        public int Luminosity { get; set; }
    }


}
