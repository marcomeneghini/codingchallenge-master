using ConstructionLine.CodingChallenge.Tests.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests.UnitTests
{
    public class ShirtColorIndexUnitTests
    {
        [Fact]
        public void Find1ShirtWhen1ShirtBlack()
        {
            // arrange
            var shirt = SampleDataBuilder.GenerateSingleShirt(Size.Large, Color.Black);

            // act
            ShirtColorIndex shirtColorIndex = new ShirtColorIndex(new List<Shirt> { shirt });
            var actualShirts = shirtColorIndex.Find(new SearchOptions { Colors = new List<Color> { Color.Black } });

            // assert
            Assert.Single(actualShirts);
            Assert.Equal(shirt.Id, actualShirts.First().Id);
        }

        [Theory]
        [MemberData(nameof(ShirtsData))]
        public void FindXShirtsByColor(List<Shirt> shirts, List<Color> colors, int shirtsCount)
        {
            ShirtColorIndex shirtColorIndex = new ShirtColorIndex(shirts);

            var shirtsFound = shirtColorIndex.Find(new SearchOptions { Colors = colors });

            Assert.Equal(shirtsCount, shirtsFound.Count());
        }

        public static IEnumerable<object[]> ShirtsData
        {
            get
            {
                int blackShirtsCount = 3;
                var blackShirts = SampleDataBuilder.GenerateShirts(blackShirtsCount, Size.Large, Color.Black);
                int blueShirtsCount = 4;
                var blueShirts = SampleDataBuilder.GenerateShirts(blueShirtsCount, Size.Large, Color.Blue);
                int redShirtsCount = 5;
                var redShirts = SampleDataBuilder.GenerateShirts(redShirtsCount, Size.Large, Color.Red);

                var shirts = blackShirts.Concat(blueShirts).Concat(redShirts).ToList();
                return new[]
                {
                    new object[] { shirts,new List<Color> { Color.Black }, blackShirtsCount },
                    new object[] { shirts,new List<Color> { Color.Blue }, blueShirtsCount },
                    new object[] { shirts, new List<Color> { Color.Red }, redShirtsCount },
                    new object[] { shirts, new List<Color> { Color.Red, Color.Black }, redShirtsCount+ blackShirtsCount },
                    new object[] { shirts, new List<Color> { Color.Red, Color.Black ,Color.Blue}, redShirtsCount+ blackShirtsCount+ blueShirtsCount }
                };
            }
        }

    }
}
