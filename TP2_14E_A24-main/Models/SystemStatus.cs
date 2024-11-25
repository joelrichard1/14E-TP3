
namespace Automate.Models
{
    public class SystemStatus
    {
        public bool AreWindowsActive { get; set; }
        public bool AreSprinklersActive { get; set; }
        public bool IsHeatingActive { get; set; }
        public bool AreLightsActive { get; set; }
        public bool IsVentilationActive { get; set; }
    }
}