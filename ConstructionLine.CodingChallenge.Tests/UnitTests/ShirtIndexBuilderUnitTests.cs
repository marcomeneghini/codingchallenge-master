using ConstructionLine.CodingChallenge.Tests.SampleData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests.UnitTests
{
    public class ShirtIndexBuilderUnitTests
    {
        [Fact]
        public void Build2IndexesWhen1Shirt()
        {
            // arrange
            var shirt = SampleDataBuilder.GenerateSingleShirt(Size.Large, Color.Black);

            // act
            ShirtIndexBuilder shirtIndexBuilde = new ShirtIndexBuilder();
            var actualIndexes = shirtIndexBuilde.BuildIndexes(new List<Shirt> { shirt });

            // assert
            Assert.Equal(2, actualIndexes.Count);           
        }

    }
}
