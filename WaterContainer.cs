using System;

namespace PotionApp
{
    public class WaterContainer
    {
        public string Name { get; set; } = "";
        public int Capacity { get; set; }
        public int Amount { get; set; }
        public bool Active { get; set; } = true;

        public override string ToString()
        {
            string status = Active ? "" : " (Suspended)";
            return $"{Name}: {Amount}/{Capacity}{status}";
        }
    }
}
