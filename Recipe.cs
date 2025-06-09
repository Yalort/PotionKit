using System;

namespace PotionApp
{
    public class Recipe
    {
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public int Animal { get; set; }
        public int Berry { get; set; }
        public int Fungi { get; set; }
        public int Herb { get; set; }
        public int Magic { get; set; }
        public int Mineral { get; set; }
        public int Root { get; set; }
        public int Solution { get; set; }
        public string Special { get; set; } = "";

        public static readonly string Header = string.Format(
            "{0,-15} {1,3} {2,3} {3,3} {4,3} {5,3} {6,3} {7,3} {8,3} {9}",
            "Name", "Ani", "Ber", "Fun", "Her", "Mag", "Min", "Roo", "Sol", "Special");

        public int TotalIngredients => Animal + Berry + Fungi + Herb + Magic + Mineral + Root + Solution;

        public override string ToString()
        {
            return string.Format(
                "{0,-15} {1,3} {2,3} {3,3} {4,3} {5,3} {6,3} {7,3} {8,3} {9}",
                Name,
                Animal,
                Berry,
                Fungi,
                Herb,
                Magic,
                Mineral,
                Root,
                Solution,
                Special);
        }
    }
}
