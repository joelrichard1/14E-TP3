
namespace Automate.Models
{
    public interface ICropConditions
    {
        public int DayMinTemperature { get; set; } 
        public int DayMaxTemperature { get; set; } 
        public int NightMinTemperature { get; set; } 
        public int NightMaxTemperature { get; set; } 
        public int MinHumidity { get; set; }
        public int MaxHumidity { get; set; }
        public int MinLux { get; set; }
        public int MaxLux { get; set; }
    }
}