using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Color
    {
        public Guid Id { get; }

        public string Name { get; }

        private Color(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Color Red = new Color(Guid.NewGuid(), "Red");
        public static Color Blue = new Color(Guid.NewGuid(), "Blue");
        public static Color Yellow = new Color(Guid.NewGuid(), "Yellow");
        public static Color White = new Color(Guid.NewGuid(), "White");
        public static Color Black = new Color(Guid.NewGuid(), "Black");


        public static List<Color> All =
            new List<Color>
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            };

        // implement Equald and GetHashCode as the class will be a key in a lookup

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Color)
            {
                return Id.Equals(((Color)obj).Id);
            }
            return false;
        }
    }
}