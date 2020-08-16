using ConstructionLine.CodingChallenge.Tests.SampleData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests.UnitTests
{
    public class ShirtIndexScannerUnitTests
    {
        [Fact]
        public void GetObjectWhen2IndexesMergeResults()
        {
            // arrange
            var searchOptions = new SearchOptions();
            var shirts = Generate3LargeShirts_BlackBlueRed();
            var mockIndex1 = new Mock<IObjectIndex<Shirt>>();
            mockIndex1.Setup(x => x.Find(searchOptions)).Returns(shirts);
            var mockIndex2 = new Mock<IObjectIndex<Shirt>>();
            mockIndex2.Setup(x => x.Find(searchOptions)).Returns(shirts);
            // act
            ShirtIndexScanner shirtIndexScanner = new ShirtIndexScanner();
            var actualShirts =  shirtIndexScanner.GetObjects(new List<IObjectIndex<Shirt>> { mockIndex1.Object, mockIndex2.Object }, searchOptions);

            // assert
            Assert.Equal(shirts.Count, actualShirts.Count());
         
        }

        [Fact]
        public void GetObjectWhen2IndexesNoResults()
        {
            // arrange
            var searchOptions = new SearchOptions();
            var mockIndex1 = new Mock<IObjectIndex<Shirt>>();
           
            mockIndex1.Setup(x => x.Find(searchOptions)).Returns(Generate3LargeShirts_BlackBlueRed());
            var mockIndex2 = new Mock<IObjectIndex<Shirt>>();
            mockIndex2.Setup(x => x.Find(searchOptions)).Returns(Generate3MediumShirts_BlackBlueRed());
            // act
            ShirtIndexScanner shirtIndexScanner = new ShirtIndexScanner();
            var actualShirts = shirtIndexScanner.GetObjects(new List<IObjectIndex<Shirt>> { mockIndex1.Object, mockIndex2.Object }, searchOptions);

            // assert
            Assert.Empty(actualShirts);
        }

        [Fact]
        public void GetObjectWhen2Indexes1Results()
        {
            // arrange
            var searchOptions = new SearchOptions();
            var mockIndex1 = new Mock<IObjectIndex<Shirt>>();
            var shirts1 = Generate3LargeShirts_BlackBlueRed();
            var shirts2 = new List<Shirt> { shirts1.First(), SampleDataBuilder.GenerateSingleShirt(Size.Medium, Color.Black) };
            mockIndex1.Setup(x => x.Find(searchOptions)).Returns(shirts1);
            var mockIndex2 = new Mock<IObjectIndex<Shirt>>();
            mockIndex2.Setup(x => x.Find(searchOptions)).Returns(shirts2);
            // act
            ShirtIndexScanner shirtIndexScanner = new ShirtIndexScanner();
            var actualShirts = shirtIndexScanner.GetObjects(new List<IObjectIndex<Shirt>> { mockIndex1.Object, mockIndex2.Object }, searchOptions);

            // assert
            Assert.Equal(1, actualShirts.Count());
        }

        private List<Shirt> Generate3LargeShirts_BlackBlueRed()
        {
            return new List<Shirt>
            {
                SampleDataBuilder.GenerateSingleShirt(Size.Large,Color.Black),
                SampleDataBuilder.GenerateSingleShirt(Size.Large,Color.Blue),
                SampleDataBuilder.GenerateSingleShirt(Size.Large,Color.Red),
            };
        }

        private List<Shirt> Generate3MediumShirts_BlackBlueRed()
        {
            return new List<Shirt>
            {
                SampleDataBuilder.GenerateSingleShirt(Size.Medium,Color.Black),
                SampleDataBuilder.GenerateSingleShirt(Size.Medium,Color.Blue),
                SampleDataBuilder.GenerateSingleShirt(Size.Medium,Color.Red),
            };
        }
    }
}
