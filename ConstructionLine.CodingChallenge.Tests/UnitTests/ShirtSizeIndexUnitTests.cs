using ConstructionLine.CodingChallenge.Tests.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests.UnitTests
{
    public class ShirtSizeIndexUnitTests
    {
        [Fact]
        public void Find1ShirtWhen1SizeSmall()
        {
            // arrange
            var shirt = SampleDataBuilder.GenerateSingleShirt(Size.Small, Color.Black);

            // act
            ShirtSizeIndex shirtSizeIndex = new ShirtSizeIndex(new List<Shirt> { shirt });
            var actualShirts = shirtSizeIndex.Find(new SearchOptions { Sizes = { Size.Small } });

            // assert
            Assert.Single(actualShirts);
            Assert.Equal(shirt.Id, actualShirts.First().Id);
        }

        [Theory]
        [MemberData(nameof(ShirtsData))]
        public void FindXShirtsBySize(List<Shirt> shirts, List<Size> sizes, int shirtsCount)
        {
            ShirtSizeIndex shirtSizeIndex = new ShirtSizeIndex(shirts);

            var shirtsFound = shirtSizeIndex.Find(new SearchOptions { Sizes = sizes });

            Assert.Equal(shirtsCount, shirtsFound.Count());
        }

        public static IEnumerable<object[]> ShirtsData
        {
            get
            {
                int smallShirtsCount = 3;
                var smallShirts = SampleDataBuilder.GenerateShirts(smallShirtsCount, Size.Small, Color.Black);
                int mediumShirtsCount = 4;
                var mediumShirts = SampleDataBuilder.GenerateShirts(mediumShirtsCount, Size.Medium, Color.Blue);
                int largeShirtsCount = 5;
                var largeShirts = SampleDataBuilder.GenerateShirts(largeShirtsCount, Size.Large, Color.Red);

                var shirts = smallShirts.Concat(mediumShirts).Concat(largeShirts).ToList();
                return new[]
                {
                    new object[] { shirts, new List<Size> { Size.Small }, smallShirtsCount },
                    new object[] { shirts, new List<Size> { Size.Medium }, mediumShirtsCount },
                    new object[] { shirts, new List<Size> { Size.Large }, largeShirtsCount },
                    new object[] { shirts, new List<Size> { Size.Large, Size.Medium }, largeShirtsCount+ mediumShirtsCount },
                     new object[] { shirts, new List<Size> { Size.Large, Size.Medium, Size.Small }, largeShirtsCount+ mediumShirtsCount+ smallShirtsCount }
                };
            }
        }
    }
}
