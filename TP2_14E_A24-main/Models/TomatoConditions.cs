
namespace Automate.Models
{
    public class TomatoConditions : ICropConditions
    {
        public int DayMinTemperature { get; set; } = 20; 
        public int DayMaxTemperature { get; set; } = 27; 
        public int NightMinTemperature { get; set; } = 18; 
        public int NightMaxTemperature { get; set; } = 22; 
        public int MinHumidity { get; set; } = 60;
        public int MaxHumidity { get; set; } = 85;
        public int MinLux { get; set; } = 400;
        public int MaxLux { get; set; } = 1200;
    }
}