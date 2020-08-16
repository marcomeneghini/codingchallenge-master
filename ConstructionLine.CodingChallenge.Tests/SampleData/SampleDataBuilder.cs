using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge.Tests.SampleData
{
    public class SampleDataBuilder
    {
        private readonly int _numberOfShirts;

        private readonly Random _random = new Random();

        
        public SampleDataBuilder(int numberOfShirts)
        {
            _numberOfShirts = numberOfShirts;

        }


        public List<Shirt> CreateShirts()
        {
            return Enumerable.Range(0, _numberOfShirts)
                .Select(i => new Shirt(Guid.NewGuid(), $"Shirt {i}", GetRandomSize(), GetRandomColor()))
                .ToList();
        }

       
        private Size GetRandomSize()
        {
            
            var sizes = Size.All;
            var index = _random.Next(0, sizes.Count);
            return sizes.ElementAt(index);
        }


        private Color GetRandomColor()
        {
            var colors = Color.All;
            var index = _random.Next(0, colors.Count);
            return colors.ElementAt(index);
        }

        public static Shirt GenerateSingleShirt(Size size, Color color)
        {
            var id = Guid.NewGuid();
            return new Shirt(id, id.ToString(), size, color);
        }

        public static List<Shirt> GenerateShirts(int count, Size size, Color color)
        {
            var shirts = new List<Shirt>();
            for (int i = 0; i < count; i++)
            {
                shirts.Add(GenerateSingleShirt(size, color));
            }
            return shirts;
        }
    }
}