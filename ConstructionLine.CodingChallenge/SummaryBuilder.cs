using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public class SummaryBuilder : ISummaryBuilder
    {
        public SearchResults GetShirtResult(List<Shirt> shirts)
        {
            var colorCounts = Color.All.Select(x => new ColorCount { Color = x, Count = 0 }).ToList();
            var sizeCounts = Size.All.Select(x => new SizeCount { Size = x, Count = 0 }).ToList();

            foreach (var colorCount in colorCounts)
            {
                colorCount.Count = shirts.Where(x => x.Color.Equals(colorCount.Color)).Count();
            }
            foreach (var sizeCount in sizeCounts)
            {
                sizeCount.Count = shirts.Where(x => x.Size.Equals(sizeCount.Size)).Count();
            }

            //foreach (var shirt in shirts)
            //{
            //    var curColorCount = colorCounts.FirstOrDefault(x => x.Color.IsEqual(shirt.Color));
            //    var curSizeCount = sizeCounts.FirstOrDefault(x => x.Size.IsEqual(shirt.Size));
            //    curColorCount.Count++;
            //    curSizeCount.Count++;
            //}
            return new SearchResults
            {
                Shirts = shirts,
                ColorCounts = colorCounts,
                SizeCounts = sizeCounts
            };
        }
    }
}
