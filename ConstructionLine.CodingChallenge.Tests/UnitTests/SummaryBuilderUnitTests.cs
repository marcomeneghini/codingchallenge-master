using ConstructionLine.CodingChallenge.Tests.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests.UnitTests
{
    public class SummaryBuilderUnitTests
    {
        [Fact]
        public void GetShirtResultWhen1SmallBlackReturnSmall1Black1()
        {
            var shirt = SampleDataBuilder.GenerateSingleShirt(Size.Small, Color.Black);

            var summaryBuilder = new SummaryBuilder();

            var actualResults = summaryBuilder.GetShirtResult(new List<Shirt> { shirt });

            var blackShirtsCount = actualResults.ColorCounts.First(x => x.Color.Id == Color.Black.Id).Count;
            var smallShirtsCount = actualResults.SizeCounts.First(x => x.Size.Id == Size.Small.Id).Count;
            Assert.Single(actualResults.Shirts);
            Assert.Equal(1, blackShirtsCount);
            Assert.Equal(1, smallShirtsCount);
        }
    }
}
