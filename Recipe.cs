using System;

namespace PotionApp
{
    public class Recipe
    {
        public string Name { get; set; } = "";
        public int Animal { get; set; }
        public int Berry { get; set; }
        public int Fungi { get; set; }
        public int Herb { get; set; }
        public int Magic { get; set; }
        public int Mineral { get; set; }
        public int Root { get; set; }
        public int Solution { get; set; }

        public int TotalIngredients => Animal + Berry + Fungi + Herb + Magic + Mineral + Root + Solution;

        public override string ToString()
        {
            return $"{Name} (Total: {TotalIngredients})";
        }
    }
}
