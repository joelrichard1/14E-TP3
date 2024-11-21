
namespace Automate.Models
{
    public class Tomato
    {
        public double MinTemperature { get; set; } = 18.5;
        public double MaxTemperature { get; set; } = 26.5;
        public int MinLux { get; set; } = 25000;
        public int MaxLux { get; set; } = 50000;
        public double MinHumidity { get; set; } = 60.0;
        public double MaxHumidity { get; set; } = 85.0;
    }
}