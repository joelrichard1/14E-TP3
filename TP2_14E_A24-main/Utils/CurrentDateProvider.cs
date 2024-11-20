using Automate.Interfaces;
using System;

namespace Automate.Utils
{
    public class CurrentDateProvider : ICurrentDateProvider
    {
        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
